using SocialMedia.Web.Api.Infrastructure.MultiTenant.Resolvers;
using SocialMedia.Web.Api.Infrastructure.Services;

namespace SocialMedia.Web.Api.Infrastructure.MultiTenant.Services
{
    public class MultiTenantService : IMultiTenantService
    {
        private string tenantId;
        private readonly ITenantMappingService _tenantMappingService;

        public MultiTenantService(ITenantMappingService tenantMappingService)
        {
            _tenantMappingService = tenantMappingService;
        }

        public string GetCurrentTenantId() => tenantId;
        public string SetCurrentTenantId(string tenantId) => this.tenantId = tenantId;

        public Guid? GetUserId() => _tenantMappingService.GetUserByTenantId(tenantId);

    }
}
