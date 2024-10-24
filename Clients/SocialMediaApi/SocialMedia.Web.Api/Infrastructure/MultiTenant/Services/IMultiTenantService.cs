namespace SocialMedia.Web.Api.Infrastructure.MultiTenant.Services
{
    public interface IMultiTenantService
    {
        public string GetCurrentTenantId();
        public string SetCurrentTenantId(string tenantId);
    }
}
