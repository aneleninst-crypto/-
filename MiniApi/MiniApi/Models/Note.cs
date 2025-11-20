namespace MiniApi.Models;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public bool IsCompleted { get; set; } = false;
    public User User { get; set; }

    public Note(int id, string title, string description, User user)
    {
        Id = id;
        Title = title;
        Description = description;
        User = user;
    }
}