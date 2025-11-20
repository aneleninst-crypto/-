namespace MiniApi.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }

    public User(int id, string login)
    {
        Id = id;
        Login = login;
    }
}