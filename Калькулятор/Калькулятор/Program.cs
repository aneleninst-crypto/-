ShowInstructions();
while (true)
{
    var input = Console.ReadLine();
if (input.ToLower() == "exit")
{
    break;
}
if (input.ToLower() == "help")
{
    ShowInstructions();
}
else 
Console.WriteLine(ProcessUserInput(input));
}

static double ProcessUserInput(string input)
{
var numbers = ParseExpression(input);
var operand1 = double.Parse(numbers[0]);
var operand2 = double.Parse(numbers[2]);
var operatorr = char.Parse(numbers[1]);

var result = FunctionSelector(operand1,operand2,operatorr);
return result;
}

static string[] ParseExpression(string input)
{
    return input.Trim().Split(" ");
}


static double FunctionSelector (double operand1, double operand2, char operatorr)
{ 
    Dictionary<char, Func<double, double, double>> operations = new Dictionary<char, Func<double, double, double>>
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
    else
    {
            throw new ArgumentException("Неизвестный оператор");
    }
}

static double Divide (double dividend, double divider)
{
return dividend / divider;
}

static double Add(double dividend, double divider)
{
    return dividend + divider;
}

static double Subtraction(double dividend, double divider)
{
return dividend - divider;
}

static double Multiplication(double dividend, double divider)
{
    return dividend * divider;
}

static double Modulo(double dividend, double divider)
{
    return dividend % divider;
}

static double Exponentiation(double dividend, double divider)
{
    return Math.Pow(dividend, divider);
}
static void ShowInstructions()
{
    Console.WriteLine("Привет! Это иструкция: введите выражение в формате число-знак-число. " +
                  "В качестве знаков используйте: +, -, *, /, %, ^. Команды: Help - вызвать иструкцию, " +
                  "команда Exit - выйти из программы.\n");
}