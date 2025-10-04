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

/* ============================================================
   CLASS: Reference — represents scripture reference details
   ============================================================ */
class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
            return $"{_book} {_chapter}:{_startVerse}";
        else
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}

/* ============================================================
   CLASS: Word — represents an individual word in scripture
   ============================================================ */
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

/* ============================================================
   CLASS: Scripture — holds words and logic for hiding/display
   ============================================================ */
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords()
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int wordsToHide = Math.Min(3, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{text}";
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}

/* ============================================================
   CLASS: ScriptureLibrary — loads multiple scriptures from file
   ============================================================ */
class ScriptureLibrary
{
    public static List<Scripture> LoadFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return scriptures;
        }

        foreach (string line in File.ReadLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split('|');
            if (parts.Length < 5)
            {
                Console.WriteLine($"Skipping invalid line: {line}");
                continue;
            }

            try
            {
                string book = parts[0].Trim();
                int chapter = int.Parse(parts[1]);
                int startVerse = int.Parse(parts[2]);
                int endVerse = int.Parse(parts[3]);
                string text = parts[4].Trim();

                Reference reference = new Reference(book, chapter, startVerse, endVerse);
                scriptures.Add(new Scripture(reference, text));
            }
            catch
            {
                Console.WriteLine($"Error parsing line: {line}");
            }
        }

        return scriptures;
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
