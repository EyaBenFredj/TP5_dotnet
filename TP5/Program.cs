using RestoManager_YourName.Models.RestosModel; // ✅ Replace with your real namespace
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Register DbContext with connection string
builder.Services.AddDbContext<RestosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestosConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Middleware pipeline
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Proprietaires}/{action=Index}/{id?}");

app.Run();