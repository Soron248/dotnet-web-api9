var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

app.MapGet("/", () => "Your Home");

app.MapGet("/about", () =>
{
    var responce = new
    {
        StatusCode = 207,
        Message = "About from obj",
        Success = true,
    };
    return Results.Ok(responce);
});

app.MapPost("/blog", () =>
{
    return Results.NoContent();
});

app.MapGet("/hello", (HttpContext context) =>
{
    var isHtml = context.Request.Query["html"] == "true";

    if (isHtml)
    {
        return Results.Content("<h1>Hello</h1>", "text/html");
    }
    else
    {
        return Results.Json(new { message = "Hello" });
    }
});

//app.MapGet("/hello", (HttpContext context) =>
//{
//    return context.Request.Query["html"] == "true"
//        ? Results.Content("<h1>Hello</h1>", "text/html")
//        : Results.Json(new { message = "Hello" });
//});



app.MapDelete("/error", () =>
{
    return Results.NoContent();
});

var products = new List<Products>()
{
    new Products("i phone 16",5,5200.5),
    new Products("samsung",6,800.7)
};

app.MapGet("/product", () =>
{
    return Results.Ok(products);
});

app.Run();

public record Products(string name, int quantity, double price);
