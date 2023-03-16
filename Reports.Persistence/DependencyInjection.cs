using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportsApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ReportsPersistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<ReportsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IReportsDbContext>(provider =>
            provider.GetService<ReportsDbContext>());
            return services;
        }
    }
}
