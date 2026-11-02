namespace LinkedLists;

internal class Program
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();
        string option;

        do
        {
            ShowMenu();
            option = Console.ReadLine() ?? "0";

            switch (option)
            {
                case "1":
                {
                    Console.Write("Value: ");
                    if (TryReadValue(out var value))
                    {
                        list.Add(value);
                        Console.WriteLine("Value added.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid value.");
                    }
                    break;
                }
                case "2":
                    if (list.IsEmpty)
                    {
                        Console.WriteLine("The list is empty.");
                    }
                    else
                    {
                        Console.WriteLine(list.ToStringForward());
                    }
                    break;
                case "3":
                    if (list.IsEmpty)
                    {
                        Console.WriteLine("The list is empty.");
                    }
                    else
                    {
                        Console.WriteLine(list.ToStringBackward());
                    }
                    break;
                case "4":
                    if (list.IsEmpty)
                    {
                        Console.WriteLine("The list is empty.");
                    }
                    else
                    {
                        list.SortDescending();
                        Console.WriteLine("List sorted descending.");
                    }
                    break;
                case "5":
                    if (list.IsEmpty)
                    {
                        Console.WriteLine("The list is empty.");
                    }
                    else
                    {
                        Console.WriteLine("Mode(s): " + string.Join(", ", list.GetModes()));
                    }
                    break;
                case "6":
                    if (list.IsEmpty)
                    {
                        Console.WriteLine("The list is empty.");
                    }
                    else
                    {
                        foreach (var occurrence in list.GetOccurrences())
                        {
                            Console.WriteLine(occurrence.Value + " " + new string('*', occurrence.Count));
                        }
                    }
                    break;
                case "7":
                {
                    Console.Write("Value: ");
                    if (!TryReadValue(out var value))
                    {
                        Console.WriteLine("Invalid value.");
                    }
                    else if (list.Exists(value))
                    {
                        Console.WriteLine("The value exists.");
                    }
                    else
                    {
                        Console.WriteLine("The value does not exist.");
                    }
                    break;
                }
                case "8":
                {
                    Console.Write("Value: ");
                    if (!TryReadValue(out var value))
                    {
                        Console.WriteLine("Invalid value.");
                    }
                    else if (list.RemoveFirst(value))
                    {
                        Console.WriteLine("Value removed.");
                    }
                    else
                    {
                        Console.WriteLine("Value not found.");
                    }
                    break;
                }
                case "9":
                {
                    Console.Write("Value: ");
                    if (!TryReadValue(out var value))
                    {
                        Console.WriteLine("Invalid value.");
                    }
                    else
                    {
                        int removed = list.RemoveAll(value);
                        if (removed > 0)
                        {
                            Console.WriteLine(removed + " occurrence(s) removed.");
                        }
                        else
                        {
                            Console.WriteLine("Value not found.");
                        }
                    }
                    break;
                }
                case "0":
                    Console.WriteLine("Goodbye.");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
        while (option != "0");
    }

    static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Show forward");
        Console.WriteLine("3. Show backward");
        Console.WriteLine("4. Sort descending");
        Console.WriteLine("5. Show mode(s)");
        Console.WriteLine("6. Show graph");
        Console.WriteLine("7. Exists");
        Console.WriteLine("8. Remove one occurrence");
        Console.WriteLine("9. Remove all occurrences");
        Console.WriteLine("0. Exit");
        Console.Write("Option: ");
    }

    static bool TryReadValue(out int value) => int.TryParse(Console.ReadLine(), out value);
}
