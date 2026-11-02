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

    public void SortDescending()
    {
        if (isDescending)
        {
            return;
        }

        Node<T>? current = head;
        while (current != null)
        {
            // swap both links of every node
            Node<T>? next = current.Next;
            current.Next = current.Previous;
            current.Previous = next;
            current = next;
        }

        Node<T>? oldHead = head;
        head = tail;
        tail = oldHead;
        isDescending = true;
    }

    public List<(T Value, int Count)> GetOccurrences()
    {
        List<(T Value, int Count)> occurrences = new List<(T Value, int Count)>();

        if (head == null)
        {
            return occurrences;
        }

        T value = head.Value;
        int count = 0;
        Node<T>? current = head;

        while (current != null)
        {
            // equal values sit next to each other, a new value closes the group
            if (current.Value.CompareTo(value) != 0)
            {
                occurrences.Add((value, count));
                value = current.Value;
                count = 0;
            }

            count++;
            current = current.Next;
        }

        occurrences.Add((value, count));
        return occurrences;
    }

    public List<T> GetModes()
    {
        List<(T Value, int Count)> occurrences = GetOccurrences();
        int maxCount = 0;

        foreach (var occurrence in occurrences)
        {
            if (occurrence.Count > maxCount)
            {
                maxCount = occurrence.Count;
            }
        }

        List<T> modes = new List<T>();
        foreach (var occurrence in occurrences)
        {
            if (occurrence.Count == maxCount)
            {
                modes.Add(occurrence.Value);
            }
        }

        return modes;
    }

    public bool Exists(T value)
    {
        Node<T>? current = head;

        while (current != null)
        {
            if (current.Value.CompareTo(value) == 0)
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public bool RemoveFirst(T value)
    {
        Node<T>? current = head;

        while (current != null)
        {
            if (current.Value.CompareTo(value) == 0)
            {
                Unlink(current);
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public int RemoveAll(T value)
    {
        int removed = 0;
        Node<T>? current = head;

        while (current != null)
        {
            Node<T>? next = current.Next;

            if (current.Value.CompareTo(value) == 0)
            {
                Unlink(current);
                removed++;
            }

            current = next;
        }

        return removed;
    }

    private void Unlink(Node<T> node)
    {
        if (node.Previous == null)
        {
            head = node.Next;
        }
        else
        {
            node.Previous.Next = node.Next;
        }

        if (node.Next == null)
        {
            tail = node.Previous;
        }
        else
        {
            node.Next.Previous = node.Previous;
        }

        Count--;
    }

    // strict compare leaves equal values behind the ones already there
    private bool GoesBefore(T value, T existing)
    {
        int comparison = value.CompareTo(existing);
        return isDescending ? comparison > 0 : comparison < 0;
    }
}
