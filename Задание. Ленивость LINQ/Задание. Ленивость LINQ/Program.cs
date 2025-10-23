List<Person> persons = new()
{
    new() { FirstName = "Виталий", LastName = "Цаль", Age = 33 },
    new() { FirstName = "Куджо", LastName = "Джотаро", Age = 40 },
    new() { FirstName = "Юрий", LastName = "Хованский", Age = 34 },
    new() { FirstName = "Михаил", LastName = "Петров", Age = 15 },
    new() { FirstName = "Виталий", LastName = "Гачиев", Age = 40 },
    new() { FirstName = "Юрий", LastName = "Гагарин", Age = 34 },
};

var filterd = FilterPersons(persons, "Виталий",null,40);
Console.WriteLine(filterd.Count());





List<Person> FilterPersons(List<Person> all, string firstName = null, string lastName = null, int age = 0)
{
    IEnumerable<Person> filterPersons = all;
    if (firstName != null)
    {
        filterPersons = filterPersons.Where(person => person.FirstName.Contains(firstName));
    }

    if (lastName != null)
    {
        filterPersons = filterPersons.Where(person => person.LastName.Contains(lastName));
    }

    if (age != 0)
    {
        filterPersons = filterPersons.Where(person => person.Age == age);
    }
    return filterPersons.ToList();
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    
}