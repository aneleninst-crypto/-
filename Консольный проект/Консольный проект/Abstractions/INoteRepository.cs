using Консольный_проект.Models;

namespace Консольный_проект.Abstractions;

public interface INoteRepository
{
    List<Note> GetAllNotes();
    public Note GetNoteById(int id);
    public void AddNote(string? title, string? description, DateTime createdDate, User user);
    public void UpdateNote(int id, string? title = null, string? description = null);
    public void DeleteNote(int id); 
    public void CompleteNote(int id);
}