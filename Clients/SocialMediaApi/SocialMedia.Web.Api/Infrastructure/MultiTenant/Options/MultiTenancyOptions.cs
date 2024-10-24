using SocialMedia.Web.Api.Infrastructure.MultiTenant.Options;

namespace SocialMedia.Web.Api.Infrastructure.MultiTenant.Options
{
    public class MultiTenancyOptions
    {
        internal bool InternalUseCookieResolver { get; private set; }
        internal bool InternalUseHeaderResolver { get; private set; }
        internal bool InternalUseQueryStringResolver { get; private set; }
        internal bool InternalUseUrlRouteResolver { get; private set; }


        public MultiTenancyOptions UseCookieResolver() 
        {
            InternalUseCookieResolver = true;
            return this;
        }

        public MultiTenancyOptions UseHeaderResolver()
        {
            InternalUseHeaderResolver = true;
            return this;
        }

        public MultiTenancyOptions UseQueryStringResolver()
        {
            InternalUseQueryStringResolver = true;
            return this;
        }

        public MultiTenancyOptions UseUrlRouteResolver()
        {
            InternalUseUrlRouteResolver = true;
            return this;
        }


        public bool AtLeastOneActive => InternalUseUrlRouteResolver
                                        |
                                        InternalUseHeaderResolver
                                        |
                                        InternalUseQueryStringResolver
                                        |
                                        InternalUseCookieResolver;

    }
}