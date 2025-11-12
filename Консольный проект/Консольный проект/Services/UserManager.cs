using System.Text.Json;
using Консольный_проект.Abstractions;
using Консольный_проект.Models;

namespace Консольный_проект.Services;

public class UserManager : IUserManager
{
    private User _user = null; //nullable
    private const string _userFile = "user.json"; //имя

    public User Register(string name)
    {
        User user = new(name);
        _user = user;
        File.WriteAllText(_userFile,JsonSerializer.Serialize(_user));
        return _user;
    }

    public User Login()
    {
        if (!File.Exists(_userFile))
        { 
            return _user;
        }

        var user = File.ReadAllText(_userFile);
        if (!string.IsNullOrEmpty(user))
        {
            _user = JsonSerializer.Deserialize<User>(user)!;
        } 
        return _user;
    }
}