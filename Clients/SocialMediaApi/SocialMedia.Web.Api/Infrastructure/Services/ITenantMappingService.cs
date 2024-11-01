
namespace SocialMedia.Web.Api.Infrastructure.Services
{
    public interface ITenantMappingService
    {
        Guid? GetUserByTenantId(string tenantId);
    }
}