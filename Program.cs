var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return "Your Home";
});
app.MapGet("/about", () =>
{
    return "Your About";
});
app.MapGet("/blog", () =>
{
    return "Your blog";
});

app.Run();
