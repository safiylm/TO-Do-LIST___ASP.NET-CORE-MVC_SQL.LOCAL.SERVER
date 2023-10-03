using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TODOLIST_ASP.NET_CORE_MVC.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodolistContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("todolist_connexion") ?? throw new InvalidOperationException("Connection string 'todolistContext' not found.")));

// Add services to the container.
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
