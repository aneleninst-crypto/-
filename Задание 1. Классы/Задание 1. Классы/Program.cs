
public class Author
{
    public string Name;
    public DateTime RegistrationDate = DateTime.UtcNow;
    public List<Note> Notes;
}

public class Note
{
    public string BookName;
    public string Description;
    public DateTime DateOfCreation = DateTime.UtcNow;
    public bool IsExecuted;
    public Author Author;
}