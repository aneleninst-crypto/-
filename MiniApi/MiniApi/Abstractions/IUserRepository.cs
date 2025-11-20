using MiniApi.Models;

namespace MiniApi.Abstractions;

public interface IUserRepository
{
    public void CreateUser(string login);
    public List<User> GetAllUsers();
    public User? GetUserById(int id);
}