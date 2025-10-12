using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("=== Scripture Memorizer ===\n");

        // Load library of scriptures from file
        List<Scripture> scriptures = ScriptureLibrary.LoadFromFile("scriptures.txt");

        // Added status feedback for user
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found. Please ensure 'scriptures.txt' exists and is formatted correctly.");
            return;
        }
        else
        {
            Console.WriteLine($"Loaded {scriptures.Count} scripture(s) successfully.\n");
        }

        Console.WriteLine("Press Enter to begin memorizing...");
        Console.ReadLine();

        // Randomly select a scripture to memorize
        Random random = new Random();
        Scripture selected = scriptures[random.Next(scriptures.Count)];

        // Main memorization loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(selected.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input?.Trim().ToLower() == "quit")
                break;

            if (selected.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(selected.GetDisplayText());
                Console.WriteLine("\nAll words hidden — great job!");
                break;
            }

            selected.HideRandomWords();
        }

        Console.WriteLine("\nProgram ended.");
    }
}

/*
===============================================================
Creative Enhancements
---------------------------------------------------------------
1. Added ScriptureLibrary class to load multiple scriptures 
   from a file ("scriptures.txt") instead of hardcoding one.
2. Program randomly selects a scripture at runtime to 
   encourage broader memorization.
3. Includes user feedback showing how many scriptures loaded.
4. Includes error handling for file issues and bad formatting.
===============================================================
*/
