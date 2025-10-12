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
