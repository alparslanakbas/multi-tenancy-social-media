﻿namespace SocialMedia.Web.Api.Infrastructure.MultiTenant.Resolvers
{
    public class MultiTenantQueryStringResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
    {
        public string Resolve()
        {
            return httpContextAccessor.HttpContext.Request?.Query[IMultiTenantResolver.TenantIdKey].ToString();
        }
    }
}
