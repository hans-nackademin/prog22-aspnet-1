using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Identity;
using WebApp.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddScoped<SignUpViewModel>();
builder.Services.AddScoped<SignInViewModel>();

builder.Services.AddIdentity<CustomIdentityUser, IdentityRole>(x =>
{
    x.Password.RequiredLength = 8;
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<IdentityContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/auth/signin";
    x.AccessDeniedPath = "/auth/accessdenied";
});






var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
