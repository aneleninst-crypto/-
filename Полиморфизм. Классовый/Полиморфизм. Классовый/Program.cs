var animals = new List<Animal>
{
    new Fox(),
    new Wolf(),
    new Rabbit(),
};
foreach (var animal in animals)
{
    animal.Run();
}

public abstract class Animal
{
    public virtual void Run()
    {
        Console.WriteLine("I am animal. I am running for my life!");
    }
}

public class Rabbit : Animal
{
    public override void Run()
    {
        Console.WriteLine("I am running from predators");
    }
}

public class Wolf : Animal
{
    public override void Run()
    {
        Console.WriteLine("I am running for tasty rabbit ;)");
    }
}

public class Fox : Animal
{
    
}