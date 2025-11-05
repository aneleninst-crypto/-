interface IPrinter //вместо этого интерфейса выделить 2 интерфейса: IPrint и IPrintColor
{
    void PrintInConsole(string message);
    void PrintInWebPage(string message, string url);
    void PrintInFile(string message, string path);
    void ChangeConsolePrintColor(ConsoleColor color);
    ConsoleColor GetCurrentConsoleColor();
}
public class Printer : IPrinter // Мне кажется тут нарушение SRP, то есть один класс выполняет уж слишком много всего
{
    private ConsoleColor _privatePrintColor; //Зачем в названии поля private?
                                                                //Бесполезное дублирование информации
                                                                //Зачем присваивать цвет?
    public void ChangeConsolePrintColor(ConsoleColor color)
    {
        _privatePrintColor = color;
    }
    public ConsoleColor GetCurrentConsoleColor() => _privatePrintColor;
    //тут пробел
    public void PrintInConsole(string message)
    {
// Set font color to selected    //А почему это надпись просто в комментариях, а не выводится на консоль?
        Console.ForegroundColor = _privatePrintColor;
        Console.WriteLine(message);
// Востанавливаем поведение по умолчанию
        Console.ForegroundColor = ConsoleColor.White; //неожидаемое поведение
    }
    public void PrintInFile(string message, string path)
    {
        var writer = new StreamWriter(path); //стоило использовать using
        writer.WriteLine(message);
    }
    public void PrintInWebPage(string message, string url)
    {
// У нас нет подключения к интернету
        throw new NotImplementedException();
    }
}