using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// we can add service here anywhere above "var app = builder.Build();" this line

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    //here we're configuring the connection string and making the name of  connection string name as "defaultConnection"

    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));


});

builder.Services.AddCors();

builder.Services.AddScoped<ITokenService, TokenService>();






var app = builder.Build();
//middlewares
// Configure the HTTP request pipeline.

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));


app.MapControllers();

app.Run();
