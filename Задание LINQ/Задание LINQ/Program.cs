using System.Globalization;

List<string> names = new()
{
    "Миша",
    "Вася",
    "Петя",
    "Гриша"
};

var firstName = names.First();
Console.WriteLine(firstName);


var filteredNames = names.Skip(1).Take(2);
foreach (var name in  filteredNames )
{
    Console.WriteLine(name);
}

var filteredNames1 = names.Where(name => name.StartsWith("М"));
foreach (var name in filteredNames1)
{
    Console.WriteLine(name);
}

var filteredNames2 = names.Where(name => name.Contains("я"));
foreach (var name in  filteredNames2)
{
    Console.WriteLine(name);
}

var filteredNames3 = names.Where(name => name.Contains("я")).Count();
Console.WriteLine(filteredNames3);

var filteredNames4 = names.Contains("Петя");
Console.WriteLine(filteredNames4);

var filteredNames5 = names.OrderBy(name => name);
foreach (var name in filteredNames5)
{
    Console.WriteLine(name);
}