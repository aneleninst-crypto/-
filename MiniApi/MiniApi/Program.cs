using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR;
using MiniApi.Abstractions;
using MiniApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<INoteRepository, NoteRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/user", (string login, IUserRepository userRepository)
    => userRepository.CreateUser(login));

app.MapGet("/user", (IUserRepository userRepository) 
    => userRepository.GetAllUsers());

app.MapPost("/notes", (
    int userId,
    string title,
    string description,
    IUserRepository userRepository,
    INoteRepository noteRepository) =>
{
    var user = userRepository.GetUserById(userId);
    if (user == null)
    {
        return Results.NotFound($"User with id {userId} not found");
    }

    noteRepository.CreateNote(title, description, user);

    return Results.Ok("Note created successfully");
});

app.MapGet("/notes/user/{userId}", (
        int userId,
        IUserRepository userRepository,
        INoteRepository noteRepository) =>
{
    var notes = noteRepository.GetNotesByUserId(userId);
    var user = userRepository.GetUserById(userId);
    if (user == null)
    {
        return Results.NotFound($"User with id {userId} not found");
    }
    return Results.Ok(notes);
});

app.MapPut("/notes/{noteId}/user/{userId}", (
    int userId,
    int noteId,
    string? title,
    string? description,
    IUserRepository userRepository,
    INoteRepository noteRepository) =>
{
    var user = userRepository.GetUserById(userId);
    if (user == null)
    {
        return Results.NotFound($"User with id {userId} not found");
    }

    var updated = noteRepository.ChangeNote(userId, noteId, title, description);
    if (!updated)
    {
        return Results.NotFound($"Note {noteId} not found on user with {userId}");
    }
    return Results.Ok("Note updated successfully");
});

app.MapDelete("/notes/{noteId}/user/{userId}", (
    int userId,
    int noteId,
    IUserRepository userRepository,
    INoteRepository noteRepository) =>
{
    var user = userRepository.GetUserById(userId);
    if (user == null)
    {
        return Results.NotFound($"User with id {userId} not found");
    }

    var delete = noteRepository.DeleteNote(userId, noteId);
    if (!delete)
    {
        return Results.NotFound("Note not deleted");
    }

    return Results.Ok("Note deleted successfully");
});

app.Run();