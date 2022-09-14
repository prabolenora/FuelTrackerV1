using Quota.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuotaDBContext>(
  opts =>
  {
      opts.EnableSensitiveDataLogging();
      opts.EnableDetailedErrors();
      opts.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection"));
  }, ServiceLifetime.Transient
);
var app = builder.Build();

app.MapGet("/quota/{val}", async (string val, QuotaDBContext db) =>
{
    var result = await db.Quotas.ToListAsync();
    return Results.Ok(val);
});

app.MapPost("/quota", async (Quotas quota, QuotaDBContext db) =>
{
    await db.AddAsync(quota);
    await db.SaveChangesAsync();
    // var result = await db.Authentication.ToListAsync();
    //return Results.Ok(val);
});

app.MapPut("/updateQuota", async (string vehicleRegistrationNumber,double usedQuota, QuotaDBContext db) =>
{
    try
    {
        var regVehicle = await db.Quotas.FindAsync(vehicleRegistrationNumber);
        double currentQuota = usedQuota;
        if (regVehicle != null)
        {
            regVehicle.remainingQuota = regVehicle.remainingQuota - usedQuota;
            await db.SaveChangesAsync();
        }
        else
        {
            //return Results.NotFound("Vehicle not found");
        }
     //   await db.SaveChangesAsync();
    }
    catch(Exception ex)
    {

    }
});


app.Run();


