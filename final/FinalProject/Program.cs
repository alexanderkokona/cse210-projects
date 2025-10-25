using System;
using System.Collections.Generic;

// --- Base Classes ---
abstract class Workout
{
    public DateTime Date;
    public int DurationMinutes;
    public int Intensity;

    public abstract double CalculateCaloriesBurned();
    public virtual string GetWorkoutSummary() { return "Workout summary not implemented."; }
}

class CardioWorkout : Workout
{
    public double DistanceMiles;
    public double Pace;

    public override double CalculateCaloriesBurned()
    {
        return 0; // placeholder
    }

    public override string GetWorkoutSummary()
    {
        return $"Cardio Workout on {Date.ToShortDateString()}, Duration: {DurationMinutes} mins";
    }
}

class StrengthWorkout : Workout
{
    public List<Exercise> Exercises = new List<Exercise>();

    public override double CalculateCaloriesBurned()
    {
        return 0; // placeholder
    }

    public override string GetWorkoutSummary()
    {
        return $"Strength Workout on {Date.ToShortDateString()}, Exercises: {Exercises.Count}";
    }

    public void AddExercise(Exercise exercise)
    {
        Exercises.Add(exercise);
    }
}

class Exercise
{
    public string Name;
    public int Sets;
    public int Reps;
    public double WeightUsed;

    public double CalculateExerciseVolume() { return 0; }
    public string GetExerciseDetails() { return Name; }
}

// --- Supporting Classes ---
class WorkoutLog
{
    public List<Workout> Workouts = new List<Workout>();

    public void AddWorkout(Workout workout)
    {
        Workouts.Add(workout);
    }

    public List<Workout> GetWorkoutsByType(string type) { return Workouts; }
    public double GetTotalCaloriesBurned() { return 0; }
}

class Goal
{
    public string Description;
    public string GoalType;
    public double TargetValue;
    public double CurrentValue;
    public bool IsCompleted;

    public void UpdateProgress(double amount) { }
    public bool CheckIfCompleted() { return false; }
    public string GetGoalSummary() { return Description; }
}

class User
{
    public string Name;
    public int Age;
    public double Weight;
    public double Height;
    public WorkoutLog WorkoutLog = new WorkoutLog();
    public List<Goal> Goals = new List<Goal>();

    public void AddWorkout(Workout workout) { WorkoutLog.AddWorkout(workout); }
    public void AddGoal(Goal goal) { Goals.Add(goal); }
    public void ViewProgressSummary() { Console.WriteLine("Progress summary placeholder."); }
}

class ProgressTracker
{
    public User User;

    public string GenerateWeeklySummary() { return "Weekly summary placeholder."; }
    public string GenerateMonthlySummary() { return "Monthly summary placeholder."; }
    public string GetMotivationalFeedback() { return "Keep going!"; }
}

// --- Program Entry Point ---
class Program
{
    static void Main(string[] args)
    {
        User currentUser = new User();
        Console.Write("Enter your name: ");
        currentUser.Name = Console.ReadLine();

        Console.WriteLine($"Hello, {currentUser.Name}! Welcome to Fitness Tracker & Planner.");

        // Simple interaction: log a cardio workout
        CardioWorkout cw = new CardioWorkout();
        cw.Date = DateTime.Now;
        cw.DurationMinutes = 30;
        cw.DistanceMiles = 3;
        currentUser.AddWorkout(cw);

        Console.WriteLine(cw.GetWorkoutSummary());

        // View placeholder summary
        currentUser.ViewProgressSummary();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
