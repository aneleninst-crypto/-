HashSet<A> @set = new();
var el1 = new A {Value = 1};
var el2 = new A {Value = 1};
@set.Add(el1);
Console.WriteLine(@set.Contains(el2));
struct A
{
    public int Value { get; set; }
    public override int GetHashCode()
    {
        Console.WriteLine("GetHashCode");
        return Value;
    }

    // public override bool Equals(object? obj)
    // {
    //     if (obj is A other)
    //         return Value == other.Value;
    //     return false;
    // }
}