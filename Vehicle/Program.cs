using Vehicle.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using ZXing.QrCode;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VehicleDBContext>(
  opts =>
  {
      opts.EnableSensitiveDataLogging();
      opts.EnableDetailedErrors();
      opts.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection"));
  }, ServiceLifetime.Transient
);
var app = builder.Build();

app.MapGet("/vehicles/{VehicleRegNumber}", async (string VehicleRegNumber) =>
{
    using(var client = new HttpClient())
    {
        client.BaseAddress = new Uri("https://bvdyi87mea.execute-api.us-east-1.amazonaws.com/RegisteredVehicle");

        using(HttpResponseMessage response= await client.GetAsync(client.BaseAddress))
        {
            string  resContent = response.Content.ReadAsStringAsync().Result;


            List<VehicleInfoDTO>? vehicleInfoList = JsonConvert.DeserializeObject<List<VehicleInfoDTO>>(resContent);

            if (vehicleInfoList != null) {
               IEnumerable<VehicleInfoDTO> requestVehicleInfo = vehicleInfoList.Where(x=>x.vehicleRegistrationNumber.Trim() == VehicleRegNumber);
                if (requestVehicleInfo.Count() > 0)
                {
                    return Results.Ok(requestVehicleInfo);
                } 

            }
            response.EnsureSuccessStatusCode();
            return Results.NotFound();
        }
    }
});

app.MapGet("/vehicles", async (VehicleDBContext db) =>
{
    var result = await db.Vehicles.ToListAsync();
    return Results.Ok(result);
});

app.MapGet("/genQR/{VehicleRegNumber}/{GUID}", async (string VehicleRegNumber,string GUID) =>
{
    string bitecode = null;
    var QrcodeContent = VehicleRegNumber + "_" + GUID;
    
    var width = 250; // width of the Qr Code    
    var height = 250; // height of the Qr Code    
    var margin = 0;
    var qrCodeWriter = new ZXing.BarcodeWriterPixelData
    {
        Format = ZXing.BarcodeFormat.QR_CODE,
        Options = new QrCodeEncodingOptions
        {
            Height = height,
            Width = width,
            Margin = margin
        }
    };
    var pixelData = qrCodeWriter.Write(QrcodeContent);
    using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
    using (var ms = new MemoryStream())
    {
        var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        try
        {
            System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }
        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        bitecode = Convert.ToBase64String(ms.ToArray());
    }
    return Results.Ok(bitecode);
});

app.MapPost("/vehicles", async (Vehicles vehicle, VehicleDBContext db) =>
{
    await db.AddAsync(vehicle);
    await db.SaveChangesAsync();
    // var result = await db.Authentication.ToListAsync();
    //return Results.Ok(val);
});


app.Run();
