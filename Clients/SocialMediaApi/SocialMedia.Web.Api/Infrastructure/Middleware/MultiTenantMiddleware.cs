
using SocialMedia.Web.Api.Infrastructure.MultiTenant.Resolvers;
using SocialMedia.Web.Api.Infrastructure.MultiTenant.Services;

namespace SocialMedia.Web.Api.Infrastructure.Middleware
{
    public class MultiTenantMiddleware(IEnumerable<IMultiTenantResolver> resolvers) : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var multiTenantService = context.RequestServices.GetRequiredService<IMultiTenantService>();

            foreach (var resolver in resolvers)
            {
                var tenantId = resolver.Resolve();

                if (string.IsNullOrWhiteSpace(tenantId))
                    continue;

                multiTenantService.SetCurrentTenantId(tenantId);

                return next(context);
            }

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return context.Response.WriteAsync("No tenant found");
        }
    }
}
