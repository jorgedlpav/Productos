using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC.Data;
using MiPrimerAppMVC.Data.Repository;
using MiPrimerAppMVC.Data.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductosContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("ProductosContext")));
builder.Services.AddScoped<IProductoRepository,ProductoRepository>();

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

app.Run();
