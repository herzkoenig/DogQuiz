// https://anthonysimmon.com/referencing-external-docker-containers-dotnet-aspire-custom-resources/
// keycloak guide: https://fiodar.substack.com/p/hosting-a-keycloak-container-in-dotnet-aspire
// https://apps-on-azure.net/dotnet/2024/2024-09-26-aspire-keycloak-part1.html

using Aspire.Hosting;
using Aspire.Hosting.Keycloak;

var builder = DistributedApplication.CreateBuilder(args);

var sqlserver = builder.AddSqlServer("sqlserver")
    //.WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var sqldb = sqlserver.AddDatabase("sqldb");

var migrationService = builder.AddProject<Projects.DogQuiz_MigrationService>("migration")
    .WithReference(sqldb)
    .WaitFor(sqldb);

var keycloak = builder.AddKeycloak("keycloak", 8080);

builder.AddProject<Projects.DogQuiz_API>("api")
    .WithReference(sqldb)
    .WithReference(keycloak)
    .WaitForCompletion(migrationService);

builder.Build().Run();