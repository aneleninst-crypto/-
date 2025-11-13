using System.Text.Json;
using Консольный_проект.Abstractions;
using Консольный_проект.Models;

namespace Консольный_проект.Services;

public class UserManager : IUserManager
{
    private User? _user = null;
    private const string UserFile = "user.json";

    public User Register(string name)
    {
        User user = new(name);
        _user = user;
        File.WriteAllText(UserFile,JsonSerializer.Serialize(_user));
        return _user;
    }

    public User Login()
    {
        if (!File.Exists(UserFile))
        { 
            return _user;
        }

        var user = File.ReadAllText(UserFile);
        if (!string.IsNullOrEmpty(user))
        {
            _user = JsonSerializer.Deserialize<User>(user)!;
        } 
        return _user;
    }
}