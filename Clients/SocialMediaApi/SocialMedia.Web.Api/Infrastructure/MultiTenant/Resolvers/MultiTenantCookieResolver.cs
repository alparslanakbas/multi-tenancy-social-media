namespace SocialMedia.Web.Api.Infrastructure.MultiTenant.Resolvers
{
    public class MultiTenantCookieResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
    {
        public string Resolve()
        {
            return httpContextAccessor.HttpContext.Request.Cookies[IMultiTenantResolver.TenantIdKey].ToString();
        }
    }
}
