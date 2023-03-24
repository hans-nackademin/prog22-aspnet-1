using _01_DataAccessLayers.Contexts;
using _01_DataAccessLayers.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SqlContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddDbContext<NoSqlContext>(x => x.UseCosmos(builder.Configuration.GetConnectionString("NoSql")!, builder.Configuration.GetSection("CosmosDbName").Value!));
builder.Services.AddScoped<ProductService>();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
