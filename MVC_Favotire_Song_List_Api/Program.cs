using MVC_Favotire_Song_List_Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// **
// Db Connection settings
//var connectionString = builder.Configuration.GetConnectionString("conexion");
string server  = "localhost";
string DbUser  = "root";
string UserPwd = "LaContrase�aPropia";
string DbName  = "favorite_songs";
var connectionString = $"server={server}; uid={DbUser}; pwd={UserPwd}; database={DbName}";
var serverVersion    = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<favorite_songsContext>(dbContextOptions => 
    dbContextOptions.UseMySql(connectionString, serverVersion));
//**


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
