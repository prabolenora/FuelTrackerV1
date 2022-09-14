using Vehicle.DataAccess;
using Microsoft.EntityFrameworkCore;

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
app.MapGet("/vehicles/{val}", async (string val, VehicleDBContext db) =>
{
    var result = await db.Vehicles.ToListAsync();
    return Results.Ok(val);
});

app.MapPost("/vehicles", async (Vehicles vehicle, VehicleDBContext db) =>
{
    await db.AddAsync(vehicle);
    await db.SaveChangesAsync();
    // var result = await db.Authentication.ToListAsync();
    //return Results.Ok(val);
});


app.Run();
