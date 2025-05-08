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


List<Category> categories = new List<Category>();

app.MapGet("/api/categories", () =>
{
    return Results.Ok(categories);
});

app.MapPost("/api/categories", () =>
{
    var NewCategory1 = new Category
    {
       CateId = Guid.Parse("8f04110d-288b-497f-95dc-5d91bc5fc49c"),
        Name = "Product one",
        Description = "Electronics Product and EET",
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };
    var NewCategory2 = new Category
    {
        CateId = Guid.Parse("8f04110d-288b-497f-95dc-5d91bc5fc49d"),
        Name = "Product two",
        Description = "Toiletries & Co.",
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };
    categories.Add(NewCategory1);
    categories.Add(NewCategory2);
    return Results.Created($"/api/categories", new[] {NewCategory1,NewCategory2} );
});

app.MapPut("/api/categories", () =>
{
    var findCategory = categories.FirstOrDefault(c => c.CateId == Guid.Parse("8f04110d-288b-497f-95dc-5d91bc5fc49d"));
    if (findCategory == null)
    {
        return Results.NotFound("Category id not matched");
    }
    findCategory.Name = "Product two updated";
    findCategory.UpdatedAt = DateTime.UtcNow;
    return Results.NoContent();
});

app.MapDelete("/api/categories", () =>
{
    var findCategory = categories.FirstOrDefault(c => c.CateId == Guid.Parse("8f04110d-288b-497f-95dc-5d91bc5fc49c"));
    if (findCategory == null)
    {
        return Results.NotFound("Category id not matched");
    }
    categories.Remove(findCategory);
    return Results.NoContent();
});

app.Run();

public record Category
{
    public Guid CateId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
};
