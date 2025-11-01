using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using midterm_project.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the controller.
builder.Services.AddControllersWithViews();

// Connection string
var conn = builder.Configuration.GetConnectionString("LibrarySqlite")
           ?? $"Data Source={Path.Combine(builder.Environment.ContentRootPath, "Data", "Library.db")}";

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("LibrarySqlite")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LibraryContext>();

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];

        // ✅ Handle cancel/denial gracefully
        options.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
        {
            OnRemoteFailure = context =>
            {
                if (context.Failure?.Message?.Contains("access_denied") == true)
                {
                    context.Response.Redirect("/Identity/Account/Login?ErrorMessage=You canceled the Google login.");
                    context.HandleResponse();
                }
                else
                {
                    context.Response.Redirect("/Identity/Account/Login?ErrorMessage=External login failed.");
                    context.HandleResponse();
                }
                return Task.CompletedTask;
            }
        };
    })
    .AddFacebook(options =>
    {
        options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
        options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];

        // ✅ Handle cancel/denial gracefully
        options.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
        {
            OnRemoteFailure = context =>
            {
                if (context.Failure?.Message?.Contains("access_denied") == true)
                {
                    context.Response.Redirect("/Identity/Account/Login?ErrorMessage=You canceled the Facebook login.");
                    context.HandleResponse();
                }
                else
                {
                    context.Response.Redirect("/Identity/Account/Login?ErrorMessage=External login failed.");
                    context.HandleResponse();
                }
                return Task.CompletedTask;
            }
        };
    });


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
app.UseAuthentication(); 
app.UseAuthorization();
app.MapRazorPages();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets()
    .RequireAuthorization();
    
app.Run();


