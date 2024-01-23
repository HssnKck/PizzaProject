using Microsoft.EntityFrameworkCore;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Context;
using PizzaProject.Model.Queries;

var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddMvc();

builder.Services.AddDbContext<PizzaDbContext>(x => x.UseSqlServer("Server=DESKTOP-J9H0RUJ\\SQLEXPRESS; Database=PizzaProject; Trusted_Connection=True; TrustServerCertificate=True;"));

builder.Services.AddScoped(typeof(IDbTools<>), typeof(AdminQueries<>));

builder.Services.AddSession();

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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "default",
    areaName:"Admin",
    pattern: "Admin/{Controller=Home}/{Action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
