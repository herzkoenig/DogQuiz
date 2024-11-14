using Duende.IdentityServer.Models;

namespace DogQuiz.Server.Configuration;

public class IdentityServerConfig
{
    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "dogquiz_client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,
                RedirectUris = { "https://localhost:5000/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5000/signout-callback-oidc" },
                AllowedScopes = { "openid", "profile", "dogquiz_api" }
            }
        };
    }

    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>
        {
            new ApiScope("dogquiz_api", "Dog Quiz API")
        };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("dogquiz_api", "Dog Quiz API")
            {
                Scopes = { "dogquiz_api" }
            }
        };
    }
}
