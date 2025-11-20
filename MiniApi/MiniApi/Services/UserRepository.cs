using MiniApi.Abstractions;
using MiniApi.Models;

namespace MiniApi.Services;

public class UserRepository : IUserRepository
{
    private List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
    }
    
    public void CreateUser(string login)
    {
        User user = new User(_users.Count + 1, login);
        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(n => n.Id == id);
    }
}