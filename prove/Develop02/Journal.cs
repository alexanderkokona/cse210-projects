using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    // Prompts for the journal
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private Random random = new Random();

    // Add a new entry with prompt, response, and mood
    public void AddEntry()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("How was your mood? (Happy, Sad, Excited, etc.): ");
        string mood = Console.ReadLine();

        Entry entry = new Entry(prompt, response, mood);
        entries.Add(entry);
        Console.WriteLine("Entry recorded!\n");
    }

    // Display all entries
    public void DisplayAll()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        Console.WriteLine("Your Journal Entries:");
        for (int i = 0; i < entries.Count; i++)
        {
            Console.WriteLine($"Entry #{i + 1}");
            entries[i].Display();
        }
    }

    // Save journal in plain text format
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
        Console.WriteLine($"Journal saved to {filename}\n");
    }

    // Load journal from plain text format
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                Entry entry = new Entry(parts[1].Trim(), parts[2].Trim(), parts[3].Trim())
                {
                    Date = parts[0].Trim()
                };
                entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename}\n");
    }

    // Save journal as JSON
    public void SaveToJson(string filename)
    {
        string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
        Console.WriteLine($"Journal saved to {filename} (JSON)\n");
    }

    // Load journal from JSON
    public void LoadFromJson(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        string json = File.ReadAllText(filename);
        entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
        Console.WriteLine($"Journal loaded from {filename} (JSON)\n");
    }

    // Save journal as CSV
    public void SaveToCsv(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Prompt,Response,Mood"); // header
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response},{entry.Mood}");
            }
        }
        Console.WriteLine($"Journal saved to {filename} (CSV)\n");
    }

    // Load journal from CSV
    public void LoadFromCsv(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        for (int i = 1; i < lines.Length; i++) // skip header
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length == 4)
            {
                Entry entry = new Entry(parts[1].Trim(), parts[2].Trim(), parts[3].Trim())
                {
                    Date = parts[0].Trim()
                };
                entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename} (CSV)\n");
    }

    // Search journal entries by keyword
    public void SearchEntries(string keyword)
    {
        var results = entries.FindAll(e =>
            e.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            e.Mood.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (results.Count == 0)
        {
            Console.WriteLine("No matching entries found.\n");
            return;
        }

        Console.WriteLine($"Search results for '{keyword}':");
        foreach (var entry in results)
        {
            entry.Display();
        }
    }

    // Edit an entry by index
    public void EditEntry(int index)
    {
        if (index < 0 || index >= entries.Count)
        {
            Console.WriteLine("Invalid entry number.\n");
            return;
        }

        Console.Write("Enter new response: ");
        entries[index].Response = Console.ReadLine();

        Console.Write("Enter new mood: ");
        entries[index].Mood = Console.ReadLine();

        Console.WriteLine("Entry updated!\n");
    }

    // Delete an entry by index
    public void DeleteEntry(int index)
    {
        if (index < 0 || index >= entries.Count)
        {
            Console.WriteLine("Invalid entry number.\n");
            return;
        }

        entries.RemoveAt(index);
        Console.WriteLine("Entry deleted!\n");
    }
}
