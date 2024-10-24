using SocialMedia.Web.Api.Infrastructure.MultiTenant.Resolvers;

namespace SocialMedia.Web.Api.Infrastructure.MultiTenant.Services
{
    public class MultiTenantService : IMultiTenantService
    {

        private string tenantId;

        public string GetCurrentTenantId() => tenantId;
        public string SetCurrentTenantId(string tenantId) => this.tenantId = tenantId;

    }
}
