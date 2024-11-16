var builder = DistributedApplication.CreateBuilder(args);

var sqlserver = builder.AddSqlServer("sqlserver")
    .WithLifetime(ContainerLifetime.Persistent);

var sqldb = sqlserver.AddDatabase("sqldb");

var migrationService = builder.AddProject<Projects.DogQuiz_MigrationService>("migration")
    .WithReference(sqldb)
    .WaitFor(sqldb);

builder.AddProject<Projects.DogQuiz_API>("api")
    .WithReference(sqldb)
    .WaitForCompletion(migrationService);

builder.Build().Run();
