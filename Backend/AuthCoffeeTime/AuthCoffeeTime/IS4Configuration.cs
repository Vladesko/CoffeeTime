using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4;

namespace AuthCoffeeTime
{
    public class IS4Configuration
    {
        public static IEnumerable<Client> GetClients() =>
            new List<Client>()
            {
                new Client()
                {
                    ClientId = "SPA",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris =
                    {
                        "http://localhost:5500/callback.html"
                    },
                    AllowedScopes =
                    {
                        "OrderApi",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5500/index.html"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:5500"
                    },
                }
            };

        public static IEnumerable<ApiScope> GetApiScopes() =>
           new List<ApiScope>()
           {
               new ApiScope("OrderApi")
           };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),

            };

        public static IEnumerable<ApiResource> GetApiResources() =>

             new List<ApiResource>
            {
                new ApiResource("OrderApi", "Order Api", new [] { JwtClaimTypes.Name})
                {
                    Scopes ={ "OrderApi" }
                },
            };
    }
}
