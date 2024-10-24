namespace SocialMedia.Web.Api.Infrastructure.MultiTenant.Resolvers
{
    public class MultiTenantUrlRouteResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
    {
        public string Resolve()
        {
            // output : https://baseUrl/{tenantId}/...
            return httpContextAccessor.HttpContext.Request?.RouteValues[IMultiTenantResolver.TenantIdKey]?.ToString();
        }
    }
}
