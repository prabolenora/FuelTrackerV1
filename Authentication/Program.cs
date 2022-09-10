var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.MapGet("/authentication/{val}", (string val) =>
{
    return Results.Ok(val);
});
app.Run();
