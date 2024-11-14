namespace DogQuiz.Server.Configuration;

using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

public static class IdentityServerSeeder
{
    public static void SeedIdentityServerConfig(ConfigurationDbContext context)
    {
        if (!context.Clients.Any())
        {
            foreach (var client in IdentityServerConfig.GetClients())
            {
                context.Clients.Add(client.ToEntity());
            }
            context.SaveChanges();
        }

        if (!context.IdentityResources.Any())
        {
            foreach (var resource in IdentityServerConfig.GetIdentityResources())
            {
                context.IdentityResources.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }

        if (!context.ApiScopes.Any())
        {
            foreach (var apiScope in IdentityServerConfig.GetApiScopes())
            {
                context.ApiScopes.Add(apiScope.ToEntity());
            }
            context.SaveChanges();
        }

        if (!context.ApiResources.Any())
        {
            foreach (var apiResource in IdentityServerConfig.GetApiResources())
            {
                context.ApiResources.Add(apiResource.ToEntity());
            }
            context.SaveChanges();
        }
    }
}