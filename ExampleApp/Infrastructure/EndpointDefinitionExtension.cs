namespace ExampleApp.Infrastructure;

public static class EndpointDefinitionExtension
{
    public static WebApplicationBuilder AddEndpointDefinitions(this WebApplicationBuilder builder, params Type[] markers)
    {
        var assemblies = markers.Select(e => e.Assembly).ToHashSet();
        
        var services = builder.Services;
        var endpointDefinitions = new List<IEndpointDefinition>();

        foreach (var assembly in assemblies)
        {
            endpointDefinitions.AddRange(assembly.ExportedTypes
                .Where(e => typeof(IEndpointDefinition).IsAssignableFrom(e) && !e.IsAbstract && !e.IsInterface)
                .Select(Activator.CreateInstance).Cast<IEndpointDefinition>());
        }

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.DefineServices(services);
        }

        services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
        return builder;
    }

    public static WebApplication UseEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.DefineEndpoints(new SubRouteBuilder(endpointDefinition.PathBase, app));
        }
        
        return app;
    }
}
