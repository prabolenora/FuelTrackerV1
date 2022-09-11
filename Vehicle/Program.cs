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
app.MapGet("/authentication/{val}", async (string val, VehicleDBContext db) =>
{
    var result = await db.Authentication.ToListAsync();
    return Results.Ok(val);
});
app.Run();
