using System.Text.Json;
using Консольный_проект.Abstractions;
using Консольный_проект.Exceptions;
using Консольный_проект.Models;

namespace Консольный_проект.Services;

public class NoteRepository : INoteRepository
{
    private List<Note> _notes;
    private const string _noteFile = "notes.json"; // Константы называются с больших букв обычно. Хотя тут приватные они, так что ситуация двоякая, лучше с большой просто

    public NoteRepository()
    {
        InitSaveFileIfNotExists();
        var notesFromFile = File.ReadAllText(_noteFile);
        _notes = JsonSerializer.Deserialize<List<Note>>(notesFromFile);
    }

    public List<Note> GetAllNotes()
    {
        return _notes;
    }

    public Note GetNoteById(int id)
    {
        var note = _notes.FirstOrDefault(n => n.Id == id);
        if (note == null)
        {
            throw new NoteNotFoundException(id);
        }
        return note;
    }

    public void AddNote(string title, string description, DateTime createdDate, User user) // в интерфейсе поля nullable, а тут нет
        => ExecuteWithSave(() =>
        {
            var note = CreateNote(title, description, createdDate, user);
            _notes.Add(note);
        });

    public void UpdateNote(int id, string title = null, string description = null) // nullable сделать
        => ExecuteWithSave(() =>
        {
            var note = GetNoteAndThrowIfNotFound(id);
            if (title != null)
            { 
                note.Title = title;
            }

            if (description != null)
            {
                note.Description = description;
            }
        });

    public void DeleteNote(int id)
        => ExecuteWithSave(() =>
        {
            var note = GetNoteAndThrowIfNotFound(id);
            _notes.Remove(note);
        });

    public void CompleteNote(int id)
        => ExecuteWithSave(() =>
        {
            var note = GetNoteAndThrowIfNotFound(id);
            note.IsCompleted = true;
        });

    private Note CreateNote(string title, string description, DateTime createdDate, User user)
    {
        return new Note(_notes.Count + 1, title, description, createdDate, user);
    }

    private static void InitSaveFileIfNotExists()
    {
        if (!File.Exists(_noteFile))
        {
            using (var writer = new StreamWriter(_noteFile))
            {
                var empty = new List<Note>();
                writer.Write(JsonSerializer.Serialize(empty));
            }
        }
    }

    private void ExecuteWithSave(Action action)
    {
        action();
        Save();
    }

    private void Save()
    {
        File.WriteAllText(_noteFile, JsonSerializer.Serialize(_notes));
    }
    
    private Note GetNoteAndThrowIfNotFound(int id)
    {
        var note = _notes.SingleOrDefault(n => n.Id == id);
        if (note == null)
        {
            throw new NoteNotFoundException(id);
        }
        return note;
    }
}