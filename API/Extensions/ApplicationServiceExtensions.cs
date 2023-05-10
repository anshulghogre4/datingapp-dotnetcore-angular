

using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<DataContext>(opt =>
            {
                //here we're configuring the connection string and making the name of  connection string name as "defaultConnection"

                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));


            });

            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;



        }
    }
}