using Microsoft.EntityFrameworkCore;
using RAD_Lab2;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdDb>(opt => opt.UseInMemoryDatabase("TodoList"));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

var adItems = app.MapGroup("/adItems");

adItems.MapGet("/", async (AdDb db) =>
    await db.Ads.ToListAsync());

adItems.MapGet("/{id}", async (int id, AdDb db) =>
    await db.Ads.FindAsync(id)
        is Ad ads
            ? Results.Ok(ads)
            : Results.NotFound());

adItems.MapGet("/seller/{id}", async (AdDb db, int id) =>
    await db.Ads.Where(ad => ad.SellerId == id).ToListAsync());

adItems.MapGet("/category/{id}", async (AdDb db, int id) =>
    await db.Ads
        .Where(ad => ad.CategoryId == id)
        .OrderBy(ad => ad.Description)
        .ToListAsync());

adItems.MapPost("/", async (Ad ad, AdDb db) =>
{
    db.Ads.Add(ad);
    await db.SaveChangesAsync();

    return Results.Created($"/adItems/{ad.Id}", ad);
});

adItems.MapPost("/bulk", async (List<Ad> ads, AdDb db) =>
{
    db.Ads.AddRange(ads);
    await db.SaveChangesAsync();

    return Results.Created($"/adItems/bulk", ads);
});

adItems.MapPut("/{id}", async (int id, Ad inputAd, AdDb db) =>
{
    var ad = await db.Ads.FindAsync(id);

    if (ad is null) return Results.NotFound();

    ad.SellerId = inputAd.SellerId;
    ad.CategoryId = inputAd.CategoryId;
    ad.Description = inputAd.Description;
    ad.Price = inputAd.Price;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

adItems.MapDelete("/{id}", async (int id, AdDb db) =>
{
    if (await db.Ads.FindAsync(id) is Ad ad)
    {
        db.Ads.Remove(ad);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});


app.Run();