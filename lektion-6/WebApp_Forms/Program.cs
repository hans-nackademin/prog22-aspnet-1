using Microsoft.EntityFrameworkCore;
using WebApp_Forms.Shared.Contexts;
using WebApp_Forms.Shared.Repositories;
using WebApp_Forms.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
