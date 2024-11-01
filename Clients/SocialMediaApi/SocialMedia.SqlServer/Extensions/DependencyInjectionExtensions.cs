using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SocialMedia.SqlServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Models.Helpers;

namespace SocialMedia.SqlServer.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraSqlServices
            (
                this IServiceCollection services,
                string connectionString,
                GetTenantIdDelegate getTenantIdDelegate
            )
        {
            services.AddDbContext<TenantMappingContext>((sp, options) =>
            {
                var logger = sp.GetRequiredService<ILogger<TenantMappingContext>>();
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                var logger = sp.GetRequiredService<ILogger<TenantMappingContext>>();
                options.UseSqlServer(connectionString);
            });

            services.AddSingleton(getTenantIdDelegate);
            return services;
        }
    }
}
