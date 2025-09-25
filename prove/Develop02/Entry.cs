using System;

public class Entry
{
    // Properties for storing the journal entry details
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }

    // Constructor used when adding a new entry
    public Entry(string prompt, string response, string mood)
    {
        Date = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    // Override ToString for saving in plain text format
    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response} | {Mood}";
    }

    // Display entry details to the console
    public void Display()
    {
        Console.WriteLine($"{Date} - Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Mood: {Mood}\n");
    }
}
