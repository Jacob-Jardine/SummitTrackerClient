using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using SummitTrackerClient.Context;
using SummitTrackerClient.Services;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureADB2C"));

//builder.Services.AddAuthorization(options => {
//    // By default, all incoming requests will be authorized according to 
//    // the default policy
//    options.FallbackPolicy = options.DefaultPolicy;
//});


// Add services to the container.
builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI(); ;
builder.Services.AddRazorPages();

var dbConnection = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Get<string>();

builder.Services.AddDbContext<SummitTrackerDbContext>(option =>
                option.UseSqlServer(dbConnection));

builder.Services.AddTransient<ISummitTrackerService, SummitTrackerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(name: "peak",
                pattern: "peak/{*peak}",
                defaults: new { controller = "peak", action = "Index" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
