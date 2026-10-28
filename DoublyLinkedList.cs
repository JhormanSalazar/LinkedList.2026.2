namespace LinkedLists;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private Node<T>? head;
    private Node<T>? tail;
    private bool isDescending = false;

    public int Count { get; private set; }

    public bool IsEmpty => head == null;

    public void Add(T value)
    {
        Node<T> node = new Node<T>(value);
        Count++;

        if (head == null)
        {
            head = node;
            tail = node;
            return;
        }

        if (GoesBefore(value, head.Value))
        {
            node.Next = head;
            head.Previous = node;
            head = node;
            return;
        }

        Node<T> current = head;
        while (current.Next != null && !GoesBefore(value, current.Next.Value))
        {
            current = current.Next;
        }

        Node<T>? next = current.Next;
        node.Previous = current;
        node.Next = next;
        current.Next = node;

        if (next == null)
        {
            tail = node;
        }
        else
        {
            next.Previous = node;
        }
    }

    public string ToStringForward()
    {
        string result = "";
        Node<T>? current = head;

        while (current != null)
        {
            if (result.Length > 0)
            {
                result += ", ";
            }

            result += current.Value;
            current = current.Next;
        }

        return result;
    }

    public string ToStringBackward()
    {
        string result = "";
        Node<T>? current = tail;

        while (current != null)
        {
            if (result.Length > 0)
            {
                result += ", ";
            }

            result += current.Value;
            current = current.Previous;
        }

        return result;
    }

    // strict compare leaves equal values behind the ones already there
    private bool GoesBefore(T value, T existing)
    {
        int comparison = value.CompareTo(existing);
        return isDescending ? comparison > 0 : comparison < 0;
    }
}
