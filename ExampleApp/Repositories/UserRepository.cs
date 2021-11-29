using ExampleApp.Models;

namespace ExampleApp.Repositories;

public interface IUserRepository
{
    public void UpdateOrCreateUser(User? user);
    public void DeleteUser(Guid id);
    public User? GetUser(Guid id);
    public ICollection<User> GetAllUsers();
}

public sealed class UserRepository : IUserRepository
{
    private IDictionary<Guid, User> _users;

    internal UserRepository(IDictionary<Guid, User> users)
    {
        _users = users;
    }

    public UserRepository() :
        this(new Dictionary<Guid, User>())
    {
    }

    public void UpdateOrCreateUser(User? user)
    {
        if (user is null)
        {
            return;
        }

        _users[user.Id] = user;
    }

    public void DeleteUser(Guid id)
    {
        if (_users.ContainsKey(id))
        {
            _users.Remove(id);
        }
    }

    public User? GetUser(Guid id)
    {
        return _users.ContainsKey(id) ? _users[id] : null;
    }

    public ICollection<User> GetAllUsers()
    {
        return _users.Values;
    }
}