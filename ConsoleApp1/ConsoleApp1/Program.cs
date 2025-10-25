var funcs = new List<Func<int, int>>();
for (int i = 0; i < 10; i++)
{
    int number = i;
    funcs.Add(x => x + number);
}

foreach(var func in funcs)
    Console.WriteLine(func(1));