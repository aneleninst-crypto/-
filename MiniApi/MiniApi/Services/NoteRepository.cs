using MiniApi.Abstractions;
using MiniApi.Models;

namespace MiniApi.Services;

public class NoteRepository : INoteRepository
{
    private List<Note> _notes;

    public NoteRepository()
    {
        _notes = new List<Note>();
    }

    public void CreateNote(string title, string description, User user)
    {
        var newNote = new Note(_notes.Count + 1, title, description, user);
        _notes.Add(newNote);
    }

    public List<Note> GetAllNotes()
    {
        return _notes;
    }

    public bool ChangeNote(int userId, int noteId,  string? title = null, string? description = null)
    {
        var note = _notes.SingleOrDefault(n => n.Id == noteId);

        if (note == null)
        {
            return false;
        }

        if (note.User.Id != userId)
        {
            return false;
        }
        
        if (title != null)
        { 
            note.Title = title;
        }

        if (description != null)
        {
            note.Description = description;
        }
        return true;
    }

    public bool DeleteNote(int userId, int noteId)
    {
        var note = _notes.SingleOrDefault(n => n.Id == noteId);
        if (note == null)
        {
            return false;
        }

        if (note.User.Id != userId)
        {
            return false;
        }
        _notes.Remove(note);
        return true;
    }

    public List<Note> GetNotesByUserId(int userId)
    {
        return _notes.Where(n => n.User.Id == userId).ToList();
    }
}