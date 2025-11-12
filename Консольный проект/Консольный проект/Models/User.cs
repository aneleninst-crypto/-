namespace Консольный_проект.Models;

public class User
{
    public string Name { get; set; } // опять же init

    public User(string name)
    {
        Name = name;
    }
}