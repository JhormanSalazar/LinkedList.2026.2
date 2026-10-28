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
        Console.WriteLine("0. Exit");
        Console.Write("Option: ");
    }

    static bool TryReadValue(out int value) => int.TryParse(Console.ReadLine(), out value);
}
