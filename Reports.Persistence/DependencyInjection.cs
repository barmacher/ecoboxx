using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApplicationsApp.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Applications.Domain;
using Ecobox.Domain;

namespace EcoboxPersistence
{
    public static class DependencyInjection  
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<ApplicationsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IApplicationsDbContext>(provider =>
            provider.GetService<ApplicationsDbContext>());




            return services;
        }
    }
}
