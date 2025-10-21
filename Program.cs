using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the controller.
builder.Services.AddControllersWithViews();

// Connection string
var conn = builder.Configuration.GetConnectionString("LibrarySqlite")
           ?? $"Data Source={Path.Combine(builder.Environment.ContentRootPath, "Data", "Library.db")}";

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite(conn));

builder.Services.AddControllersWithViews();


var app = builder.Build();

//seedind the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    LibrarySeeder.Seed(db);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();


