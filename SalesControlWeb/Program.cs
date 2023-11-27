using Microsoft.EntityFrameworkCore;
using SalesControlWeb.Data;
using SalesControlWeb.Models;

var builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("Default");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SalesControlWebDbContext>(
    options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
// Seed Service Registration Database
builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed the database
using var scope = app.Services.CreateScope();
var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
seedingService.Seed();

app.Run();
