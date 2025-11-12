using Консольный_проект.Services;

var noteRepository = new NoteRepository();
var userManager = new UserManager();
var uiControlService = new UiControlService(userManager, noteRepository);

uiControlService.Run();



//  4 пустые строчки