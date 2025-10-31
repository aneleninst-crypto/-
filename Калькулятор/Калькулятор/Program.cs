using Логгер;

ConsoleLogger consoleLogger = new();
FileLogger fileLogger = new();
var listLoggers = new List<ILogger>
{
    consoleLogger,
    fileLogger
};
var compositeLogger = new CompositeLogger(listLoggers);

Calculator calculator = new(compositeLogger);

ShowInstructions();

while (true)
{

    var input = Console.ReadLine();
    if (input?.ToLower() == "exit")
    {
        break;
    }

    if (input?.ToLower() == "help")
    {
        ShowInstructions();
    }
    else 
        try
        {
            if (input != null) 
                Console.WriteLine(calculator.ProcessUserInput(input));
        }
        catch (DivideByZeroException byZeroException)
        {
            consoleLogger.LogError(byZeroException);
        }
        catch (Exception ex)
        {
            consoleLogger.LogError(ex);
        }
}

static void ShowInstructions()
{
    Console.WriteLine("Привет!\nЭто иструкция!\nВведите выражение в формате число-знак-число. \n" +
                  "В качестве знаков используйте: +, -, *, /, %, ^. \nКоманды: Help - вызвать иструкцию, " +
                  "команда Exit - выйти из программы.\n");
}

public class Calculator
{
    private readonly ILogger _logger;

    public Calculator (ILogger logger)
    {
        _logger = logger;
    }

    public double ProcessUserInput(string input)
    {
        ParseExpression(input, out double operand1, out double operand2, out char operatorr);

        return FunctionSelector(operand1,operand2,operatorr);
    }

    static void ParseExpression(string input, out double operand1, out double operand2, out char operatorr)
    {
        var numbers =  input.Trim().Split(" ");
         operand1 = double.Parse(numbers[0]);
         operand2 = double.Parse(numbers[2]); 
         operatorr = char.Parse(numbers[1]);
        
    }

    private double FunctionSelector (double operand1, double operand2, char operatorr)
    { 
        var operations = new Dictionary<char, Func<double, double, double>>
        {
            { '+', Add },
            { '-', Subtraction },
            { '*', Multiplication },
            { '/', Divide },
            { '%', Modulo },
            { '^', Exponentiation },
        }; 
        if (operations.TryGetValue(operatorr, out var operation))
        {
            return operation(operand1, operand2);
        }
        throw new ArgumentException("Неизвестный оператор");
    }  
    
    private double Add(double dividend, double divider)
    {
        var result = dividend + divider;
        _logger.LogInformation($"Сложение: {dividend} + {divider} = {result}");
        return result;
    }

    private double Subtraction(double dividend, double divider)
    {
        var result = dividend - divider;
        _logger.LogInformation($"Вычитание: {dividend} - {divider} = {result}");
        return result;
    }

    private double Divide(double dividend, double divider)
    {
        if (divider == 0)
        {
            var ex = new DivideByZeroException("Невозможно делить на ноль");
            throw ex;
        }
        var result = dividend / divider;
        _logger.LogInformation($"Деление: {dividend} / {divider} = {result}");
        return result;
    }

    private double Multiplication(double dividend, double divider)
    {
        var result = dividend * divider;
        _logger.LogInformation($"Умножение: {dividend} * {divider} = {result}");
        return result;
    }

    private double Modulo(double dividend, double divider)
    {
        var result = dividend % divider;
        _logger.LogInformation($"Остаток от деления: {dividend} % {divider} = {result}");
        return result;
    }

    private double Exponentiation(double dividend, double divider)
    {
        var result = Math.Pow(dividend, divider);
        _logger.LogInformation($"Возведение в степень: {dividend} ^ {divider} = {result}");
        return result;
    }
}