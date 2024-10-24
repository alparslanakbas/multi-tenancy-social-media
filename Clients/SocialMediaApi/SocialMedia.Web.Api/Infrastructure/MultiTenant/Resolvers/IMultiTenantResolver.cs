using XBuddy.Models.Constants;

namespace SocialMedia.Web.Api.Infrastructure.MultiTenant.Resolvers
{
    public interface IMultiTenantResolver
    {
        public static string TenantIdKey => MultiTenantConstants.TenantId;

        string Resolve();

    }
}
