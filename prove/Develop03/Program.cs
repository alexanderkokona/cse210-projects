using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptManager promptManager = new PromptManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a text file");
            Console.WriteLine("4. Load the journal from a text file");
            Console.WriteLine("5. Save the journal to a CSV file (Excel)");
            Console.WriteLine("6. Load the journal from a CSV file (Excel)");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option (1–7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptManager.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(prompt, response, date);
                    Console.WriteLine("Entry recorded.");
                    break;

                case "2":
                    Console.WriteLine("\n--- Journal Entries ---");
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g., journal.txt): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved successfully.");
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g., journal.txt): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded successfully.");
                    break;

                case "5":
                    Console.Write("Enter filename to save (e.g., journal.csv): ");
                    string saveCsv = Console.ReadLine();
                    journal.SaveToCsv(saveCsv);
                    Console.WriteLine("Journal saved as CSV successfully.");
                    break;

                case "6":
                    Console.Write("Enter filename to load (e.g., journal.csv): ");
                    string loadCsv = Console.ReadLine();
                    journal.LoadFromCsv(loadCsv);
                    Console.WriteLine("Journal loaded from CSV successfully.");
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1–7.");
                    break;
            }
        }
    }
}

/// <summary>
/// Represents a single journal entry.
/// </summary>
class Entry
{
    private string prompt;
    private string response;
    private string date;

    public Entry(string prompt, string response, string date)
    {
        this.prompt = prompt;
        this.response = response;
        this.date = date;
    }

    public void Display()
    {
        Console.WriteLine($"{date} - {prompt}");
        Console.WriteLine($"{response}\n");
    }

    public string ToFileString()
    {
        return $"{date}|{prompt}|{response}";
    }

    public static Entry FromFileString(string fileString)
    {
        var parts = fileString.Split('|');
        return new Entry(parts[1], parts[2], parts[0]);
    }

    public string ToCsvString()
    {
        return $"{EscapeCsv(date)},{EscapeCsv(prompt)},{EscapeCsv(response)}";
    }

    public static Entry FromCsvString(string csvLine)
    {
        // Basic CSV parsing (splits on commas outside quotes)
        var parts = ParseCsvLine(csvLine);
        return new Entry(parts[1], parts[2], parts[0]);
    }

    // --- Helper methods for CSV escaping/parsing ---
    private static string EscapeCsv(string field)
    {
        if (field.Contains(",") || field.Contains("\""))
        {
            field = field.Replace("\"", "\"\"");
            return $"\"{field}\"";
        }
        return field;
    }

    private static List<string> ParseCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == '"' && !inQuotes)
            {
                inQuotes = true;
            }
            else if (c == '"' && inQuotes)
            {
                inQuotes = false;
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(current.Trim());
                current = "";
            }
            else
            {
                current += c;
            }
        }

        result.Add(current.Trim());
        return result;
    }
}

/// <summary>
/// Represents the Journal, which stores a collection of entries.
/// </summary>
class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response, string date)
    {
        entries.Add(new Entry(prompt, response, date));
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            foreach (var entry in entries)
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile(string filename)
    {
        var lines = entries.Select(e => e.ToFileString()).ToArray();
        File.WriteAllLines(filename, lines);
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            entries.Clear();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                entries.Add(Entry.FromFileString(line));
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void SaveToCsv(string filename)
    {
        List<string> lines = new List<string>();
        lines.Add("Date,Prompt,Response"); // Header row
        foreach (var entry in entries)
        {
            lines.Add(entry.ToCsvString());
        }
        File.WriteAllLines(filename, lines);
    }

    public void LoadFromCsv(string filename)
    {
        if (File.Exists(filename))
        {
            entries.Clear();
            var lines = File.ReadAllLines(filename).Skip(1); // Skip header
            foreach (var line in lines)
            {
                entries.Add(Entry.FromCsvString(line));
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

/// <summary>
/// Manages random journal prompts.
/// </summary>
class PromptManager
{
    private List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today?",
        "What made me laugh today?"
    };

    private Random random = new Random();

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
