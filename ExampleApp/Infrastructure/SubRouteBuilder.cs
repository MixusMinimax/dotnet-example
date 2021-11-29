using Microsoft.AspNetCore.Routing.Patterns;

namespace ExampleApp.Infrastructure;

public class SubRouteBuilder : IEndpointRouteBuilder
{
    private readonly IEndpointRouteBuilder _delegate;
    private readonly PathString _root;

    public SubRouteBuilder(PathString root, IEndpointRouteBuilder @delegate)
    {
        _delegate = @delegate;
        _root = root;
    }

    public IEndpointConventionBuilder MapGet(string pattern, RequestDelegate requestDelegate)
        => _delegate.MapGet(_root + pattern, requestDelegate);

    public IEndpointConventionBuilder MapPost(string pattern, RequestDelegate requestDelegate)
        => _delegate.MapPost(_root + pattern, requestDelegate);

    public IEndpointConventionBuilder MapPut(string pattern, RequestDelegate requestDelegate)
        => _delegate.MapPut(_root + new PathString(pattern), requestDelegate);

    public IEndpointConventionBuilder MapDelete(string pattern, RequestDelegate requestDelegate)
        => _delegate.MapDelete(_root + pattern, requestDelegate);

    public IEndpointConventionBuilder MapMethods(
        string pattern,
        IEnumerable<string> httpMethods,
        RequestDelegate requestDelegate)
        => _delegate.MapMethods(_root + pattern, httpMethods, requestDelegate);

    public IEndpointConventionBuilder Map(
        RoutePattern pattern,
        RequestDelegate requestDelegate)
        => _delegate.Map(_root + pattern, requestDelegate);
    
    public IEndpointConventionBuilder Map(string pattern, RequestDelegate requestDelegate)
        => _delegate.Map(_root + pattern, requestDelegate);

    public IEndpointConventionBuilder MapGet(string pattern, Delegate requestDelegate)
        => _delegate.MapGet(_root + pattern, requestDelegate);

    public IEndpointConventionBuilder MapPost(string pattern, Delegate requestDelegate)
        => _delegate.MapPost(_root + pattern, requestDelegate);

    public IEndpointConventionBuilder MapPut(string pattern, Delegate requestDelegate)
        => _delegate.MapPut(_root + pattern, requestDelegate);

    public IEndpointConventionBuilder MapDelete(string pattern, Delegate requestDelegate)
        => _delegate.MapDelete(_root + pattern, requestDelegate);

    public IEndpointConventionBuilder MapMethods(
        string pattern,
        IEnumerable<string> httpMethods,
        Delegate requestDelegate)
        => _delegate.MapMethods(_root + pattern, httpMethods, requestDelegate);

    public IEndpointConventionBuilder Map(
        RoutePattern pattern,
        Delegate requestDelegate)
        => _delegate.Map(_root + pattern, requestDelegate);
    
    public IEndpointConventionBuilder Map(string pattern, Delegate requestDelegate)
        => _delegate.Map(_root + pattern, requestDelegate);

    public IApplicationBuilder CreateApplicationBuilder() => _delegate.CreateApplicationBuilder();
    public IServiceProvider ServiceProvider => _delegate.ServiceProvider;
    public ICollection<EndpointDataSource> DataSources => _delegate.DataSources;
}