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
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1–5): ");
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
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1–5.");
                    break;
            }
        }
    }
}

/// <summary>
/// Represents a single journal entry.
/// Demonstrates abstraction by hiding implementation details behind methods.
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
}

/// <summary>
/// Represents the Journal, which stores a collection of entries.
/// Uses abstraction to manage entries without exposing the list implementation.
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
}

/// <summary>
/// Manages random journal prompts.
/// This encapsulates the logic of prompt selection.
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
