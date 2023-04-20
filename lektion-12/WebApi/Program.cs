using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Merketo")));

// Repositories


// Services


// Authentication/Identity



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