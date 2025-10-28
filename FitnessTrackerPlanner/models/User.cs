using System;
using System.Collections.Generic;

class User
{
    public string Name;
    public int Age;
    public double Weight;
    public double Height;
    public WorkoutLog WorkoutLog = new WorkoutLog();
    public List<Goal> Goals = new List<Goal>();

    public void AddWorkout(Workout workout) => WorkoutLog.AddWorkout(workout);
    public void AddGoal(Goal goal) => Goals.Add(goal);

    public void LogCardioWorkout()
    {
        CardioWorkout cw = new CardioWorkout();
        Console.Write("Enter duration (minutes): ");
        cw.DurationMinutes = int.Parse(Console.ReadLine());
        Console.Write("Enter distance (miles): ");
        cw.DistanceMiles = double.Parse(Console.ReadLine());
        cw.Date = DateTime.Now;

        AddWorkout(cw);
        Console.WriteLine("\nCardio workout logged!");
    }

    public void LogStrengthWorkout()
    {
        StrengthWorkout sw = new StrengthWorkout();
        sw.Date = DateTime.Now;
        Console.Write("How many exercises? ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nExercise {i + 1}:");
            sw.AddExercise(Exercise.CreateFromInput());
        }

        AddWorkout(sw);
        Console.WriteLine("\nStrength workout logged!");
    }

    public void LogGoal()
    {
        Goal g = Goal.CreateFromInput();
        AddGoal(g);
        Console.WriteLine("\nGoal added!");
    }

    public void ViewProgressSummary()
    {
        Console.WriteLine($"\n--- {Name}'s Progress Summary ---");
        Console.WriteLine($"\nWorkouts:");
        WorkoutLog.DisplayAllWorkouts();

        Console.WriteLine($"\nGoals:");
        if (Goals.Count == 0)
            Console.WriteLine("No goals set.");
        else
            foreach (var g in Goals)
                Console.WriteLine(g.GetGoalSummary());

        Console.WriteLine($"\nTotal Calories Burned: {WorkoutLog.GetTotalCaloriesBurned()} kcal");
    }
}
