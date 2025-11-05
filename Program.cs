using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Diagnostics;
using midterm_project.Models;
using midterm_project.Exceptions; 
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add logging (console + optional file)
builder.Logging.AddConsole();
// builder.Logging.AddFile("Logs/app_log.txt"); // optional

//  Connection string setup
var conn = builder.Configuration.GetConnectionString("LibrarySqlite")
           ?? $"Data Source={Path.Combine(builder.Environment.ContentRootPath, "Data", "Library.db")}";

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite(conn));

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
        options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryContext>();

// External login providers
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
        options.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
        {
            OnRemoteFailure = context =>
            {
                if (context.Failure?.Message?.Contains("access_denied") == true)
                {
                    context.Response.Redirect("/Identity/Account/Login?ErrorMessage=You canceled the Google login.");
                }
                else
                {
                    context.Response.Redirect("/Identity/Account/Login?ErrorMessage=External login failed.");
                }
                context.HandleResponse();
                return Task.CompletedTask;
            }
        };
    })
    .AddFacebook(options =>
    {
        options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
        options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
        options.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
        {
            OnRemoteFailure = context =>
            {
                if (context.Failure?.Message?.Contains("access_denied") == true)
                {
                    context.Response.Redirect("/Identity/Account/Login?ErrorMessage=You canceled the Facebook login.");
                }
                else
                {
                    context.Response.Redirect("/Identity/Account/Login?ErrorMessage=External login failed.");
                }
                context.HandleResponse();
                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();

//  Database seeding
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    LibrarySeeder.Seed(db);
}

//  Configure the HTTP request pipeline
// if (!app.Environment.IsDevelopment())
{
    // Use global exception handler middleware
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = MediaTypeNames.Text.Html;

            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError(exception, "An unhandled exception occurred: {Message}", exception?.Message);

            string message;
            if (exception is BookNotFoundException)
            {
                message = "<h2 style='color:red;'>Book Not Found</h2><p>The book you requested could not be located in the system.</p>";
            }
            else if (exception is DatabaseConnectionException)
            {
                message = "<h2 style='color:red;'>Database Error</h2><p>We’re having trouble connecting to the library database. Please try again later.</p>";
            }
            else
            {
                message = "<h2 style='color:red;'>Unexpected Error</h2><p>Something went wrong while processing your request.</p>";
            }

            await context.Response.WriteAsync($@"
                <html>
                    <body style='font-family:Arial;text-align:center;margin-top:80px;'>
                        {message}
                        <p><a href='/'>Return to Home</a></p>
                    </body>
                </html>");
        });
    });

    app.UseHsts();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionFeature?.Error;

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "text/html";

            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError(exception, "Unhandled exception: {Message}", exception?.Message);

            string errorTitle, errorMessage;

            if (exception is BookNotFoundException)
            {
                errorTitle = "Book Not Found";
                errorMessage = "Sorry! The book you’re looking for is not available in our library system.";
            }
            else if (exception is DatabaseConnectionException)
            {
                errorTitle = "Database Error";
                errorMessage = "We’re currently having trouble connecting to the library database. Please try again later.";
            }
            else
            {
                errorTitle = "Unexpected Error";
                errorMessage = "Something went wrong while processing your request.";
            }

            // Beautiful Bootstrap-styled error response
            await context.Response.WriteAsync($@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Error</title>
                    <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css' rel='stylesheet'>
                </head>
                <body class='bg-light d-flex flex-column align-items-center justify-content-center' style='height:100vh;'>
                    <div class='card shadow-lg p-5 text-center' style='max-width:600px;'>
                        <h1 class='text-danger mb-3'>{errorTitle}</h1>
                        <p class='lead text-muted'>{errorMessage}</p>
                        <a href='/' class='btn btn-primary mt-3'>
                            <i class='bi bi-house-door-fill'></i> Return to Home
                        </a>
                    </div>
                </body>
                </html>");
        });
    });

    app.UseHsts();
}

//  Handle HTTP status codes (404, 403, etc.)
app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

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
