using ExampleApp.Infrastructure;

var app = WebApplication
    .CreateBuilder(args)
    .AddEndpointDefinitions(typeof(Program))
    .Build()
    .UseEndpointDefinitions();

await app.RunAsync();
