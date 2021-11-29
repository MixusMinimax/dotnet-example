using ExampleApp.Infrastructure;
using ExampleApp.Models;
using ExampleApp.Repositories;

namespace ExampleApp.EndpointDefinitions;

public class UserEndpointDefinition : IEndpointDefinition
{
    public string PathBase => "/users";
    
    public void DefineEndpoints(SubRouteBuilder app)
    {
        app.MapGet("/example", () => "Example");
        app.MapPost("/{name}", CreateUser);
        app.MapGet("", GetAllUsers);
        app.MapGet("/{id}", GetUser);
        app.MapPut("/{id}", UpdateUser);
        app.MapDelete("/{id}", DeleteUser);
    }

    internal User CreateUser(UserRepository repo, string name)
    {
        var user = new User(Guid.NewGuid(), name);
        repo.UpdateOrCreateUser(user);
        return user;
    }

    internal User? UpdateUser(UserRepository repo, Guid id, string name)
    {
        if (repo.GetUser(id) is null)
        {
            return null;
        }
        var user = new User(id, name);
        repo.UpdateOrCreateUser(user);
        return user;
    }

    internal User? DeleteUser(UserRepository repo, Guid id)
    {
        var user = GetUser(repo, id);
        repo.DeleteUser(id);
        return user;
    }

    internal ICollection<User> GetAllUsers(UserRepository repo)
    {
        return repo.GetAllUsers();
    }

    internal User? GetUser(UserRepository repo, Guid id)
    {
        return repo.GetUser(id);
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton(new UserRepository());
    }
}