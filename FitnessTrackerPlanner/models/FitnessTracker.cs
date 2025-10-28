using System;
using System.Collections.Generic;
using System.Linq;

public class FitnessTracker
{
    private List<Workout> _workouts = new();

    public void LogWorkout()
    {
        Console.WriteLine("Select workout type: 1. Cardio  2. Strength");
        int type = SafeIntInput(1, 2);

        Workout workout;
        if (type == 1)
        {
            CardioWorkout cw = new CardioWorkout();
            Console.Write("Enter cardio name: ");
            cw.Name = Console.ReadLine() ?? "Cardio";
            cw.Date = DateTime.Now;
            cw.DurationMinutes = SafeIntInput(1, 300);
            cw.Intensity = SafeIntInput(1, 10);
            Console.Write("Enter distance in miles: ");
            cw.DistanceMiles = SafeDoubleInput();
            cw.Pace = cw.DurationMinutes / cw.DistanceMiles;
            workout = cw;
        }
        else
        {
            StrengthWorkout sw = new StrengthWorkout();
            Console.Write("Enter strength workout name: ");
            sw.Name = Console.ReadLine() ?? "Strength";
            sw.Date = DateTime.Now;
            sw.DurationMinutes = SafeIntInput(1, 300);
            sw.Intensity = SafeIntInput(1, 10);

            Console.Write("How many exercises? ");
            int numExercises = SafeIntInput(1, 20);
            for (int i = 0; i < numExercises; i++)
            {
                Exercise ex = new Exercise();
                Console.Write($"Exercise {i + 1} name: ");
                ex.Name = Console.ReadLine() ?? "Exercise";
                Console.Write("Sets: "); ex.Sets = SafeIntInput(1, 10);
                Console.Write("Reps: "); ex.Reps = SafeIntInput(1, 100);
                Console.Write("Weight (lbs): "); ex.Weight = SafeDoubleInput();
                sw.AddExercise(ex);
            }
            workout = sw;
        }

        _workouts.Add(workout);
        Console.WriteLine("Workout logged successfully!");
        Pause();
    }

    public void ViewSummary()
    {
        Console.WriteLine("\n=== WORKOUT SUMMARY ===");
        foreach (var w in _workouts)
        {
            Console.WriteLine(w.GetSummary());
        }
        Pause();
    }

    public List<Workout> GetWorkouts() => _workouts;

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

    private double SafeDoubleInput()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (double.TryParse(input, out double result))
                return result;
            Console.Write("Invalid input. Enter a number: ");
        }
    }

    private void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
