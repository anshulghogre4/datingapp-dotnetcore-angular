using System.Text;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});






var app = builder.Build();
//middlewares
// Configure the HTTP request pipeline.

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//we need to place authentication middleware in between cors and mapcontroller

app.UseAuthentication(); // must come first for valid token
app.UseAuthorization();// after valid token authenticated you'll have authorization

app.MapControllers();

app.Run();
