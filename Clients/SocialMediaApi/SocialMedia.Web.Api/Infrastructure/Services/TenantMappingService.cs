using SocialMedia.SqlServer.Context;

namespace SocialMedia.Web.Api.Infrastructure.Services
{
    public class TenantMappingService : ITenantMappingService
    {
        private TenantMappingContext _tenantMappingContext;
        private readonly IServiceProvider _serviceProvider;
        private Dictionary<string, Guid> _map;

        public TenantMappingService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            LoadMap();
        }

        public Guid? GetUserByTenantId(string tenantId)
        {
            return _map.TryGetValue(tenantId, out var userId) ? userId : null;
        }

        private void LoadMap()
        {
            using var scope = _serviceProvider.CreateScope();
            _tenantMappingContext = scope.ServiceProvider.GetService<TenantMappingContext>();
            _map = _tenantMappingContext.TenantMappings.ToDictionary(i => i.TenantId, i => i.UserId);
        }
    }
}
