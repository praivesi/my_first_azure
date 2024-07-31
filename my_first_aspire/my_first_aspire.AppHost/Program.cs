var builder = DistributedApplication.CreateBuilder(args);

var config = builder.Configuration;

var cache = builder.AddRedis("cache");

var apiapp = builder.AddProject<Projects.MyFirstAzure_ApiApp>("apiapp")
.WithEnvironment("OpenAI__Endpoint", config["OpenAI:Endpoint"])
.WithEnvironment("OpenAI__ApiKey", config["OpenAI:ApiKey"])
.WithEnvironment("OpenAI__DeploymentName", config["OpenAI:DeploymentName"]);

builder.AddProject<Projects.MyFirstAzure_WebApp>("webapp")
.WithReference(cache)
.WithReference(apiapp);

builder.Build().Run();
