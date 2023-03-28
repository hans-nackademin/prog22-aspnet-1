using Microsoft.EntityFrameworkCore;
using WebApp_CustomIndentity.Contexts;
using WebApp_CustomIndentity.Models.Identity;
using WebApp_CustomIndentity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddScoped<AuthService>();
builder.Services.AddDefaultIdentity<AppUser>(x =>
{

    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;

}).AddEntityFrameworkStores<DataContext>();




var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
