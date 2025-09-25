using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice = "";

        while (choice != "10")
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal (Plain Text)");
            Console.WriteLine("4. Load journal (Plain Text)");
            Console.WriteLine("5. Save journal (JSON)");
            Console.WriteLine("6. Load journal (JSON)");
            Console.WriteLine("7. Save journal (CSV)");
            Console.WriteLine("8. Load journal (CSV)");
            Console.WriteLine("9. Search / Edit / Delete entries");
            Console.WriteLine("10. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    journal.SaveToFile(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Enter JSON filename to save: ");
                    journal.SaveToJson(Console.ReadLine());
                    break;
                case "6":
                    Console.Write("Enter JSON filename to load: ");
                    journal.LoadFromJson(Console.ReadLine());
                    break;
                case "7":
                    Console.Write("Enter CSV filename to save: ");
                    journal.SaveToCsv(Console.ReadLine());
                    break;
                case "8":
                    Console.Write("Enter CSV filename to load: ");
                    journal.LoadFromCsv(Console.ReadLine());
                    break;
                case "9":
                    Console.WriteLine("1. Search entries");
                    Console.WriteLine("2. Edit an entry");
                    Console.WriteLine("3. Delete an entry");
                    Console.Write("Choose an option: ");
                    string subChoice = Console.ReadLine();

                    if (subChoice == "1")
                    {
                        Console.Write("Enter keyword to search: ");
                        journal.SearchEntries(Console.ReadLine());
                    }
                    else if (subChoice == "2")
                    {
                        Console.Write("Enter entry number to edit: ");
                        if (int.TryParse(Console.ReadLine(), out int editIndex))
                            journal.EditEntry(editIndex - 1);
                    }
                    else if (subChoice == "3")
                    {
                        Console.Write("Enter entry number to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                            journal.DeleteEntry(deleteIndex - 1);
                    }
                    break;
                case "10":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.\n");
                    break;
            }
        }
    }
}
