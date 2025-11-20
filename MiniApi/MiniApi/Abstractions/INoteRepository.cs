using MiniApi.Models;

namespace MiniApi.Abstractions;

public interface INoteRepository
{
    public void CreateNote(string title, string description, User user);
    public List<Note> GetAllNotes();
    public bool ChangeNote(int userId, int noteId, string? title = null, string? description = null);
    public bool DeleteNote(int userId, int noteId);
    public List<Note> GetNotesByUserId(int userId);
}