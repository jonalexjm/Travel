using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Interfaces;
using Travel.Core.Interfaces.Repositories;
using Travel.Core.Interfaces.Services;
using Travel.Infrastructure.Data;
using Travel.Infrastructure.Repositories;
using Travel.Infrastructure.Services;

namespace Travel.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TravelDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("dbTravel"))
            );

            return services;
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAutorService, AutorService>();
            //services.AddTransient<IAutoresHasLibroService, AutoresHasLibroService>();
            services.AddTransient<IEditorialService, EditorialService>();
            services.AddTransient<ILibroService, LibroService>();        
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
