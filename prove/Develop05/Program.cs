using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    class Program
    {
        // SAVE FILE - same folder as running exe
        private const string SAVE_FILENAME = "goals_save.txt";

        static void Main(string[] args)
        {
            var player = new Player();
            var goals = new List<Goal>();

            Console.WriteLine("Eternal Quest — Program (Console)");
            Console.WriteLine("Type the number to choose an action.\n");

            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Score: " + player.Score + "  (Level " + player.Level + ")");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Record event (complete a goal)");
                Console.WriteLine("4. Save goals & score");
                Console.WriteLine("5. Load goals & score");
                Console.WriteLine("6. Show score and level");
                Console.WriteLine("7. Quit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1": CreateGoal(goals); break;
                    case "2": ListGoals(goals); break;
                    case "3": RecordEvent(goals, player); break;
                    case "4": Save(goals, player); break;
                    case "5": Load(goals, player); break;
                    case "6": Console.WriteLine($"Score: {player.Score}  Level: {player.Level}"); break;
                    case "7": running = false; break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }

            Console.WriteLine("Exiting. Goodbye.");
        }

        static void CreateGoal(List<Goal> goals)
        {
            Console.WriteLine("Choose goal type: (1) Simple  (2) Eternal  (3) Checklist");
            Console.Write("Type: ");
            var t = Console.ReadLine()?.Trim();
            Console.Write("Title: ");
            var title = Console.ReadLine() ?? "";
            Console.Write("Description: ");
            var desc = Console.ReadLine() ?? "";
            Console.Write("Points (integer): ");
            int points = ParseIntOrDefault(Console.ReadLine(), 0);

            switch (t)
            {
                case "1":
                    goals.Add(new SimpleGoal(title, desc, points));
                    Console.WriteLine("Simple goal created.");
                    break;
                case "2":
                    goals.Add(new EternalGoal(title, desc, points));
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "3":
                    Console.Write("Required count to complete: ");
                    int req = ParseIntOrDefault(Console.ReadLine(), 1);
                    Console.Write("Bonus on completion: ");
                    int bonus = ParseIntOrDefault(Console.ReadLine(), 0);
                    goals.Add(new ChecklistGoal(title, desc, points, req, bonus));
                    Console.WriteLine("Checklist goal created.");
                    break;
                default:
                    Console.WriteLine("Unknown type - cancelled.");
                    break;
            }
        }

        static void ListGoals(List<Goal> goals)
        {
            if (!goals.Any())
            {
                Console.WriteLine("No goals defined.");
                return;
            }
            Console.WriteLine("Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetStatusString()}");
            }
        }

        static void RecordEvent(List<Goal> goals, Player player)
        {
            if (!goals.Any())
            {
                Console.WriteLine("No goals to record.");
                return;
            }

            ListGoals(goals);
            Console.Write("Select goal number to record: ");
            int idx = ParseIntOrDefault(Console.ReadLine(), -1);
            if (idx < 1 || idx > goals.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var goal = goals[idx - 1];
            int awarded = goal.RecordEvent();
            if (awarded <= 0)
            {
                Console.WriteLine("No points awarded (goal may already be complete).");
                return;
            }

            int newLevel = player.AddPoints(awarded);
            Console.WriteLine($"You gained {awarded} points.");
            if (newLevel > 0)
            {
                Console.WriteLine($"Level up! New level: {player.Level}");
            }
        }

        static void Save(List<Goal> goals, Player player)
        {
            try
            {
                using (var writer = new StreamWriter(SAVE_FILENAME))
                {
                    // First line: player's score
                    writer.WriteLine(player.Score);
                    // Then each goal line
                    foreach (var g in goals)
                    {
                        writer.WriteLine(g.Serialize());
                    }
                }
                Console.WriteLine($"Saved to {SAVE_FILENAME}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save: " + ex.Message);
            }
        }

        static void Load(List<Goal> goals, Player player)
        {
            if (!File.Exists(SAVE_FILENAME))
            {
                Console.WriteLine($"Save file {SAVE_FILENAME} not found.");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(SAVE_FILENAME);
                goals.Clear();

                if (lines.Length == 0)
                {
                    Console.WriteLine("Save file empty.");
                    return;
                }

                // First line is score
                int loadedScore = ParseIntOrDefault(lines[0], 0);
                player.SetScoreFromLoad(loadedScore);

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i].Trim();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var goal = Goal.Deserialize(line);
                    goals.Add(goal);
                }

                Console.WriteLine("Loaded save. Goals and score updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load: " + ex.Message);
            }
        }

        static int ParseIntOrDefault(string s, int def)
        {
            if (int.TryParse(s?.Trim(), out int v)) return v;
            return def;
        }
    }
}
