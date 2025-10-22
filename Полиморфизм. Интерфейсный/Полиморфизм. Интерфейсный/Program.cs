ConsoleReader consoleReader = new ConsoleReader();
ConstantReader constantReader = new ConstantReader();
IntegerParser consoleParser = new IntegerParser(consoleReader);
IntegerParser constantParser = new IntegerParser(constantReader);

Console.WriteLine(consoleParser.Parse());
Console.WriteLine(constantParser.Parse());
public interface IInputReader
{
    string ReadFromSource();
}

public class ConstantReader : IInputReader
{
    public string ReadFromSource()
    {
        return "5";
    }
}

public class ConsoleReader: IInputReader
{
    public string ReadFromSource()
    {
        var readFromSource = Console.ReadLine();
        return readFromSource;
    }
}

public class IntegerParser
{
    private readonly IInputReader _reader;
    public IntegerParser(IInputReader reader)
    {
        _reader = reader;
    }
    public int Parse()
    {
        var inputedValue = _reader.ReadFromSource() ;
        return int.Parse(inputedValue);
    }
}
