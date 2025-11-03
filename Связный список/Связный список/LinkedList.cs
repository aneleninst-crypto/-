namespace Связный_список;

public class MyLinkedList<T>
{
    public Node<T>? Head { get; set; }

    public MyLinkedList(Node<T>? head = null)
    {
        Head = head;
    }

    public Node<T> FindFirst(T value)
    {
        var current = Head;
        while (current is not null && !Equals(current.Value, value))
        {
            current = current.Next;
        }

        return current;
    }

    public void AddLast(T value)
    {
        var newNode = new Node<T>(value);

        if (Head is null)
        {
            Head = newNode;
            return;
        }

        var current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;


    }

    public void InsertAfter(T afterValue, T newValue)
    {
        var node = FindFirst(afterValue);
        if (node is null)
        {
            throw new InvalidOperationException($"Элемент со значением {afterValue} не найден");
        }

        var newNode = new Node<T>(newValue);
        newNode.Next = node.Next;
        node.Next = newNode;
    }

    public bool Remove(T value)
    {
        if (Head is null)
        {
            return false;
        }

        if (EqualityComparer<T>.Default.Equals(Head.Value, value))
        {
            Head = Head.Next;
            return true;
        }

        var current = Head;
        while (current.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Next.Value, value))
            {
                current.Next = current.Next.Next;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public bool Replace(T oldValue, T newValue)
    {
        var node = FindFirst(oldValue);
        if (node != null)
        {
            node.Value = newValue;
            return true;
        }
        return false;
    }
    
    public int GetLength()
    {
        int length = 0;
        var current = Head;
        while (current is not null)
        {
            length++;
            current = current.Next;
        }

        return length;
    }

    public IEnumerable<T> Enumerate()
    {
        var current = Head;
        while (current is not null)
        {
            yield return current.Value;
            current = current.Next;
        }

    }

    public bool IsEmpty()
    {
        return Head == null;
    }

}
