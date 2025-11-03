using Связный_список;
Console.WriteLine("Мой связный список\n");

var list = new MyLinkedList<int>();

for (int i = 0; i <= 10; i++)
{
    list.AddLast(i);
}

Console.WriteLine("1. Исходный список: ");
list.PrintToConsole();

list.InsertAfter(5, 42);
Console.WriteLine("\n2. После вставки 42 между 5 и 6: ");
list.PrintToConsole();

list.Replace(9, -1);
Console.WriteLine("\n3. После замены 9 на -1: ");
list.PrintToConsole();

list.Remove(3);
Console.WriteLine("\n4. После уданение 3: ");
list.PrintToConsole();

int length = list.GetLength();
Console.WriteLine($"\n5. Длин списка {length}");

Console.WriteLine("\n6. Итоговый список: ");
list.PrintToConsole();


