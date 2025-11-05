// Представим, что все классы в разных файлах
public class Note
{
    public int Id { get; }
    public string Title { get; }
    public bool IsCompleted { get; set; } = false; //Вроде это правильно, но я бы передала false в конструкторе 
    public Note(int id, string title)
    {
        Id = id;
        Title = title;
    }     // Я бы добавила сюда еще метод, который бы отмечал заметку как выполненную 
}
public class NoteMemoryRepository //сюда бы добавить интерфейс
{
    public static readonly List<Note> Notes = new List<Note>(); // по хорошему это поле сделать бы приватным...
                                                                // (принцип инкапсуляции)
                                                                // а еще убрать static
    public void CompleteNote(int id) 
    {
        var note = Notes.FirstOrDefault(n => n.Id == id);
        if (note is null)
        {
            throw new Exception("Note not found exception");
        }
        note.IsCompleted = true;
    }
    public void DeleteNote(int id)
    {
        var note = Notes.FirstOrDefault(n => n.Id == id);
        if (note is null)
        {
            throw new Exception("Note not found exception");     // Я думаю, что тут можно было бы просто возращать false,
                                                                 // а не бросать бесконечные ошибки. Точнее лучше бы сделать
                                                                 // так, чтобы методы в целом возращали нам bool
        }
        Notes.Remove(note);
    }
    public void AddNote(Note note)    //еще меня смущает последовательность действий.
                                      //Я бы сначала сделала Add, потом Delete, а потом complete
    {
        var a = Notes.FirstOrDefault(n => n.Id == note.Id); //неиформативное название переменной
        if (a != null)
        {
            throw new Exception("Note already exists exception");
        }
        Notes.Add(note);
    }
    public List<Note> GetNotes() => Notes;
    public Note GetNote(int id)
    {
        var note = Notes.FirstOrDefault(n => n.Id == id);
        if (note is null)
        {
            throw new Exception("Note not found exception");
        }
        return note;
    }
}