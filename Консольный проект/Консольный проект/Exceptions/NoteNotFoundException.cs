namespace Консольный_проект.Exceptions;

public class NoteNotFoundException(int id) : Exception($"Note with Id: {id}  not found");
