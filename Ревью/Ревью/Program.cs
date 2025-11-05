public class Program
{
    static void Main()
    {
        var allowedOperations = new HashSet<string> { "+", "-" };
        Console.WriteLine("Введите выражение для вычисления и нажмите enter:");
        var input = Console.ReadLine().Trim().ToLower(); //так лучше не присать, потому что может вызваться значение,
                                                         //которое равно null и дальнещие оперции не будет выполняться.
                                                         //Чтобы этого избежать следует добавить проверку на null
                                                         //Также все эти операции стоит разделить для большей читаемости кода. И вообще сё это по хорошему бы вывести в отдельную функцию.
        var splited = input.Split();
        if (splited.Length == 0)
        {
            throw new ArgumentException(nameof(input));//отсутствует обработка исключений
        }
        for (int i = 0; i < splited.Length; i++)
        {
            if (i % 2 != 0)
            {
                if (!allowedOperations.Contains(splited[i]))
                {
                    throw new ArgumentOutOfRangeException(splited[i]);   // излишняя вложенность кода
                }
            }
            else
            {
                if (!int.TryParse(splited[i], out var _))
                {
                    throw new ArgumentOutOfRangeException(splited[i]);//при данной ошибке программа может упасть,
                                                                      //можно обойтись обычной проверкой на null,
                                                                      //а также можно отправить пользователю сообщение
                                                                      //с просьбой ввести корректные данные 
                }
            }
        }
        var result = 0;
        var lastOperation = "+"; //Некорректное название переменной
        for (int i = 0; i < splited.Length; i++)
        {
            if (i % 2 != 0)
            {
                lastOperation = splited[i];
            }                                    //В этой части вообще по виду просиходит
                                                 //какая-то непонятная магия я в шоке.
            else                                 //Я думаю, что частично эту часть можно было бы организовать
                                                 //с помощью LINQ. Было бы понятнее и компактнее.
            {
                switch (lastOperation)
                {
                    case "+":
                        result += int.Parse(splited[i]);
                        break;
                    case "-":
                        result -= int.Parse(splited[i]);
                        break;
                }
            }
        }
        Console.WriteLine($"Результат: {result}");
    }
}