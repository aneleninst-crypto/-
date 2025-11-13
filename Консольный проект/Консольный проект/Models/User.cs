namespace Консольный_проект.Models;

public class User
{
    public string Name { get; init; }

    public User(string name)
    {
        Name = name;
    }
}