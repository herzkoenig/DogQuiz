var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DogQuiz_API>("dogquiz-api");

//builder.AddKeycloakContainer("Keycloak");

//var db = builder.AddSqlServer("sql").AddDatabase("db");

builder.Build().Run();
