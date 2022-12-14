using BeSpoked_Bikes.Areas.Identity;
using BeSpoked_Bikes.Data;
using BeSpoked_Bikes.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddMvcCore(options=>options.EnableEndpointRouting=false);
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<IUserReg, UserReg>();
builder.Services.AddTransient<IProductsContoller, ProductsContoller>();
builder.Services.AddTransient<ICustomerController, CustomerController>();
builder.Services.AddSyncfusionBlazor();



var app = builder.Build();

// Configure the HTTP request pipeline.
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzQ2MTk3QDMyMzAyZTMzMmUzMEdXV2c0azlZS3pUZWVEcHU5ZWpiYUhDNzVlMHA5MjZ1SzREQ1hvZk5tUFE9");

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
