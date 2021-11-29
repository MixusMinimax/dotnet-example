using ExampleApp.Infrastructure;

namespace ExampleApp.EndpointDefinitions;

// ReSharper disable once UnusedType.Global
public class ExampleEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(SubRouteBuilder app)
    {
        app.MapGet("/hello", () => "Hello, World!");
    }

    public void DefineServices(IServiceCollection services)
    {

    }
}
