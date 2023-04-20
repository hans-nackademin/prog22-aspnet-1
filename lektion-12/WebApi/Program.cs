using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;
using WebApi.Models.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Merketo")));

// Repositories
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<UserCompanyRepository>();

// Services
builder.Services.AddScoped<AddressManager>();
builder.Services.AddScoped<AuthManager>();
builder.Services.AddScoped<CompanyManager>();

// Authentication/Identity
builder.Services.AddDefaultIdentity<CustomIdentityUser>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();


var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


/*
    app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
        AllowAnyHeader = "Authorization", "Content-Type", "X-Header-Key" ....
        AllowAnyOrigin = https://localhost, http://domain.com/, http://domain.com:3333
        AllowAnyMethod = POST, PUT, PATCH, GET, DELETE, OPTION
    
*/