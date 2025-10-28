using System;
using System.IO;
using System.Text.Json;

public class ProgramController
{
    private FitnessTracker _tracker;
    private const string SaveFile = "fitness_data.json";

    public ProgramController()
    {
        _tracker = LoadData();
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== FITNESS TRACKER PLANNER ===");
            Console.WriteLine("1. Log Workout");
            Console.WriteLine("2. View Summary");
            Console.WriteLine("3. View Progress");
            Console.WriteLine("4. Save & Exit");
            Console.Write("\nSelect an option: ");

            switch (SafeIntInput(1, 4))
            {
                case 1:
                    _tracker.LogWorkout();
                    break;
                case 2:
                    _tracker.ViewSummary();
                    break;
                case 3:
                    Console.Clear();
                    ProgressTracker progress = new ProgressTracker(_tracker);

                    Console.WriteLine(progress.GenerateWeeklySummary());
                    Console.WriteLine();
                    Console.WriteLine(progress.GenerateMonthlySummary());
                    Console.WriteLine();
                    Console.WriteLine("Motivation: " + progress.GetMotivationalFeedback());

                    Pause();
                    break;
                case 4:
                    SaveData();
                    running = false;
                    break;
            }
        }
    }

    private int SafeIntInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result >= min && result <= max)
                return result;
            Console.Write($"Invalid input. Enter {min}-{max}: ");
        }
    }

    private void SaveData()
    {
        try
        {
            string json = JsonSerializer.Serialize(_tracker, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SaveFile, json);
            Console.WriteLine("\nData saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    private FitnessTracker LoadData()
    {
        try
        {
            if (File.Exists(SaveFile))
            {
                string json = File.ReadAllText(SaveFile);
                FitnessTracker? tracker = JsonSerializer.Deserialize<FitnessTracker>(json);
                Console.WriteLine("Data loaded successfully!\n");
                return tracker ?? new FitnessTracker();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }

        return new FitnessTracker();
    }

    private void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
