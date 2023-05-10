using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// we can add service here anywhere above "var app = builder.Build();" this line

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);






var app = builder.Build();
//middlewares
// Configure the HTTP request pipeline.

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//we need to place authentication middleware in between cors and mapcontroller

app.UseAuthentication(); // must come first for valid token
app.UseAuthorization();// after valid token authenticated you'll have authorization

app.MapControllers();

app.Run();
