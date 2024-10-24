using Microsoft.Extensions.DependencyInjection.Extensions;
using SocialMedia.Web.Api.Infrastructure.Middleware;
using SocialMedia.Web.Api.Infrastructure.MultiTenant.Options;
using SocialMedia.Web.Api.Infrastructure.MultiTenant.Resolvers;
using SocialMedia.Web.Api.Infrastructure.MultiTenant.Services;

namespace SocialMedia.Web.Api.Infrastructure.MultiTenant.Extensions
{
    public static class MultiTenantExtensions
    {
        public static IServiceCollection AddMultiTenancy(this IServiceCollection services, Action<MultiTenancyOptions> action)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<MultiTenantMiddleware>();
            services.AddScoped<IMultiTenantService, MultiTenantService>();

            var opt = new MultiTenancyOptions();
            action(opt);

            if (opt.InternalUseUrlRouteResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantUrlRouteResolver>());
            }

            if (opt.InternalUseQueryStringResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantQueryStringResolver>());
            }

            if (opt.InternalUseCookieResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantCookieResolver>());
            }

            if (opt.InternalUseHeaderResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantHeaderResolver>());
            }


            if (!opt.AtLeastOneActive)
                throw new Exception("Multi Tenant Resolver Not Found");

            return services;
        }


        public static IServiceCollection AddMultiTenancy(this IServiceCollection services)
        {
            AddMultiTenancy(services, opt =>
            {
                opt
                .UseUrlRouteResolver()
                .UseCookieResolver()
                .UseHeaderResolver()
                .UseQueryStringResolver();
            });

            return services;
        }


        public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder app) 
        {
            app.UseMiddleware<MultiTenantMiddleware>();
            return app;
        }

    }
}
