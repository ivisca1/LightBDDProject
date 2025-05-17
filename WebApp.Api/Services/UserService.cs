using WebApp.Api.Models;

namespace WebApp.Api.Services;

public class UserService
{
    private readonly List<User> _users = new();

    public bool Register(string email, string password)
    {
        if (_users.Any(u => u.Email == email))
            return false;

        _users.Add(new User { Email = email, Password = password });
        return true;
    }

    public bool Login(string email, string password)
    {
        return _users.Any(u => u.Email == email && u.Password == password);
    }
}
