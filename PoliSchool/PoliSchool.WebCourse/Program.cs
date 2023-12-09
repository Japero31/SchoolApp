using Microsoft.EntityFrameworkCore;
using PoliSchool.WebCourse.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agregar conexion de la base datos.
builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDbContext")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
