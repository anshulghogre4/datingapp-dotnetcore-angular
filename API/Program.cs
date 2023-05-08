using API.Data;
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






var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapControllers();

app.Run();
