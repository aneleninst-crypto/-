using Консольный_проект.Abstractions;
using Консольный_проект.Exceptions;
using Консольный_проект.Models;

namespace Консольный_проект.Services;

internal class UiControlService
{
    private readonly IUserManager _userManager;
    private readonly INoteRepository _noteRepository;
    private readonly IReadOnlyDictionary<string, Action> _uiCommandsHandlers;
    
    private bool _running = false;
    private User _user = null; // nullable User сделать
    
    public UiControlService
    (
        IUserManager userManager,
        INoteRepository noteRepository)
    {
        _userManager = userManager;
        _noteRepository = noteRepository;
        _uiCommandsHandlers = new Dictionary<string, Action>
        {
            { "register", Register},
            { "view_notes", ViewNotes},
            { "create_note", CreateNote},
            { "complete_note", CompleteNote},
            { "update_note", UpdateNote},
            { "remove_note", RemoveNote},
            { "help", Help},
            { "exit", Exit},
        };
    }

    public void Run()
    {
        _running = true;
        Console.WriteLine("Hello! This is note application. You can manage your notes here.");
        Console.WriteLine("You can start typing comands (write \"help\" for more info):");
        while (_running)
        {
            try
            { 
                Login();
                SelectionOfOperations();
            }
            catch (UserNotLoggedException log)
            {
                Console.WriteLine(log.Message);
            }
            catch (NoteNotFoundException note)
            {
                Console.WriteLine(note.Message);
            }
            catch
            {
                Console.WriteLine("Unkown exception!!!");
            }
        }
        
        Console.WriteLine($"Goodbye, {_user?.Name?? "anonymous"}!");
    }

    private void SelectionOfOperations()
    {
        var command = Console.ReadLine().Trim().ToLowerInvariant();
        if (_uiCommandsHandlers.ContainsKey(command))
        {
            _uiCommandsHandlers[command]();
        }
        else
        {
            Console.WriteLine("Unkown command!");
        }
    }

    private void Login()
    {
        if (_user == null)
        {
            _user = _userManager.Login();
        }

        if (_user != null)
        {
            Console.WriteLine($"Welcome back, {_user.Name}");
            ViewNotes();
        }
    }
    private void Register()
    {
        Console.WriteLine("Register"); 
        Console.WriteLine("Enter your name: "); 
        _user = _userManager.Register(Console.ReadLine().Trim()); // валидация на пустую строчку!!!
        Console.WriteLine($"Nice to meet you, {_user.Name}!");
    }

    private void ViewNotes()
    {
        Console.WriteLine("Your notes:\n");
        var notes = _noteRepository.GetAllNotes();
        foreach (var note in notes)
        {
            Console.WriteLine($"{note.Id} Title: {note.Title}");
            Console.WriteLine($"Description: {note.Description}");
            Console.WriteLine($"Created Date: {note.CreatedDate}");
            Console.WriteLine($"Author: {note.User.Name}");
        }
    }

    private void CreateNote()
    {
        Console.WriteLine("Title:\n ");
        var title = Console.ReadLine();
        Console.WriteLine("Description:\n");
        var description = Console.ReadLine();
        var createdDate = DateTime.Now;
        _noteRepository.AddNote(title, description, createdDate, _user);
        Console.WriteLine("Added.\n");
        ViewNotes();
    }

    private void CompleteNote()
    {
        Console.WriteLine("Input note Id:\n");
        var parseResult = int.TryParse(Console.ReadLine(), out  var noteId);
        if (parseResult)
        { 
            _noteRepository.CompleteNote(noteId);
            Console.WriteLine($"Note {noteId} completed!");
        }
        else
        { 
            Console.WriteLine("Enter an integer!");
        }
        ViewNotes();
    }

    private void UpdateNote()
    {
        var note = ParseResult();
        Console.WriteLine("Title:\n");
        var newTitle = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(newTitle))
        {
            _noteRepository.UpdateNote(note.Id, newTitle);
        }
        
        Console.WriteLine("Description:\n");
        var newDescription = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newDescription))
        {
            _noteRepository.UpdateNote(note.Id, newDescription);
        }
        
        Console.WriteLine($"Note {note.Id} updated!"); 
        ViewNotes();
    }

    private void RemoveNote()
    {
        var note = ParseResult();
        _noteRepository.DeleteNote(note.Id);
        Console.WriteLine($"Note {note.Id} deleted!");
        ViewNotes();
    }

    private void Help()
    {
        Console.WriteLine("Allowed commands:");
        Console.Write($"\t{string.Join("\n\t", _uiCommandsHandlers.Keys)}");
        Console.WriteLine();
    }

    private void Exit()
    {
        if (_user == null)
        {
            Console.WriteLine("Goodbye");
        }
        if (_user != null)
        {
            Console.WriteLine($"Goodbye, {_user.Name}");
        }

        _running = false;
    }

    private Note ParseResult()
    {
        Console.WriteLine("Input note Id:\n");
        var parseResult = int.TryParse(Console.ReadLine().Trim(), out  var noteId);
        if (!parseResult)
        {
            Console.WriteLine("Invalid Id formate!");
        }
        return _noteRepository.GetNoteById(noteId);
    }
}