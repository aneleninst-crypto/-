List<Person> persons = new()
{
    new() { FirstName = "Виталий", LastName = "Цаль", Age = 33 },
    new() { FirstName = "Куджо", LastName = "Джотаро", Age = 40 },
    new() { FirstName = "Юрий", LastName = "Хованский", Age = 34 },
    new() { FirstName = "Михаил", LastName = "Петров", Age = 15 },
    new() { FirstName = "Виталий", LastName = "Гачиев", Age = 40 },
    new() { FirstName = "Юрий", LastName = "Гагарин", Age = 34 },
};

 var filteredPersons = persons.Where(person => person.FirstName=="Юрий").Count();
 Console.WriteLine(filteredPersons);

 var filteredPersons1 = persons.Select(person => person.FirstName + " "+person.LastName);
 foreach (var person in filteredPersons1)
 {
     Console.WriteLine(person);
 }

var filteredPersons2 = persons.Average(person => person.Age);
Console.WriteLine(filteredPersons2);

var filteredPersons3 = persons.OrderBy(person => person.Age).ToList();
foreach (var person in filteredPersons3)
{
    Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");
}
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    
}