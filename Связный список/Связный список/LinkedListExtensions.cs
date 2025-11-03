namespace Связный_список;

public static class LinkedListExtensions
{
    public static void PrintToConsole<T>(this MyLinkedList<T> list)
    {
        if (list.IsEmpty())
        {
            Console.WriteLine("Список пустой");
            return;
        }

        Console.Write("Список: ");
        bool first = true;
        foreach (var item in list.Enumerate())
        {
            if (!first)
            {
                Console.Write(" -> ");
            }
            Console.Write(item);
            first = false;
        }
        Console.WriteLine();
    }
}
