using Authentication.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AuthenticationDBContext>(
  opts =>
  {
      opts.EnableSensitiveDataLogging();
      opts.EnableDetailedErrors();
      opts.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection"));
  },ServiceLifetime.Transient
);
var app = builder.Build();
app.MapGet("/authentication/{val}",async (string val, AuthenticationDBContext db) =>
{
    var result = await db.Authentication.ToListAsync();
    return Results.Ok(val);
});

app.MapPost("/authentication", async (Authentications authentication, AuthenticationDBContext db) =>
{
    await db.AddAsync(authentication);
    await db.SaveChangesAsync();
   // var result = await db.Authentication.ToListAsync();
    //return Results.Ok(val);
});
app.Run();
