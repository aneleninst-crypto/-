namespace Консольный_проект.Models;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsCompleted { get; set; } = false;
    public User User { get; set; }  

    public Note(int id, string title, string description, DateTime createdDate, User user)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedDate = createdDate;
        User = user;
    }
}