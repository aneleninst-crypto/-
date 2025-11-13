using Консольный_проект.Models;

namespace Консольный_проект.Abstractions;

public interface IUserManager
{
    public User Login (); 
    public User Register (string name);
}