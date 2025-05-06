var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/home", () =>
{
    return "Your Home";
});

app.Run();
