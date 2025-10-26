Dictionary<B, string> map = new();
var el1 = new B();
var el2 = new B();
map[el1] = "12";
map[el2] = "14";
Console.WriteLine(map[el1]);
class B
{
    private static readonly Random _random = new();
    private readonly int _hashCode;
    public B()
    {
        _hashCode = _random.Next();
    }
    public override int GetHashCode() => _hashCode;
    public override bool Equals(object obj) => true;
}