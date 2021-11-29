namespace ExampleApp.Infrastructure;

public interface IEndpointDefinition
{
    public void DefineEndpoints(SubRouteBuilder app);

    public void DefineServices(IServiceCollection services);

    public string PathBase => "";
}