using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new(
                    name: "username",
                    userClaims: new[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" })
            };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("myApi.default")
        };
        
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string>{ "myApi.default" },
                    ApiSecrets = new List<Secret>{ new("secret".Sha256()) },
                    UserClaims = new[] { ClaimTypes.Name }
                }
            };

        public static IEnumerable<Client> Clients => new Client[]
            {
                new Client
                {
                    ClientId = "ToDoApp.win",
                    ClientName = "ToDoApp Windows client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.default", "openid" }
                },
            };
    }
}