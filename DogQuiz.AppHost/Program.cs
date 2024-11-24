// https://anthonysimmon.com/referencing-external-docker-containers-dotnet-aspire-custom-resources/
// keycloak guide: https://fiodar.substack.com/p/hosting-a-keycloak-container-in-dotnet-aspire
// https://apps-on-azure.net/dotnet/2024/2024-09-26-aspire-keycloak-part1.html

//using Aspire.Hosting;
//using Aspire.Hosting.Keycloak;

using Aspire.Hosting.ApplicationModel;

var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("sqlserver")
    .WithLifetime(ContainerLifetime.Persistent);

var sqlDatabase = sqlServer.AddDatabase("sqldb");

var migrationService = builder.AddProject<Projects.DogQuiz_MigrationService>("migration")
    .WithReference(sqlDatabase)
    .WaitFor(sqlDatabase);

var keycloak = builder.AddKeycloak("keycloak", 8080);

var api = builder.AddProject<Projects.DogQuiz_API>("api")
	.WithReference(sqlDatabase)
	.WithReference(keycloak)
	.WaitForCompletion(migrationService);

var tempUi = builder.AddProject<Projects.DogQuiz_TempUI>("tempui")
	//.WithReference(api)
	.WaitFor(api)
	.WithEnvironment("API_URL_HTTP", api.GetEndpoint("http"))
	.WithEnvironment("API_URL_HTTPS", api.GetEndpoint("https"));

builder.Build().Run();