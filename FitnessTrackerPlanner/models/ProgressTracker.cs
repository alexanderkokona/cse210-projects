using System;
using System.Linq;

public class ProgressTracker
{
    private FitnessTracker _tracker;

    public ProgressTracker(FitnessTracker tracker)
    {
        _tracker = tracker;
    }

    public string GenerateWeeklySummary()
    {
        var workoutsThisWeek = _tracker.GetWorkouts()
            .Where(w => (DateTime.Now - w.Date).TotalDays <= 7).ToList();

        int totalStrengthExercises = workoutsThisWeek
            .OfType<StrengthWorkout>()
            .SelectMany(sw => sw.Exercises)
            .Count();

        double totalCardioMiles = workoutsThisWeek
            .OfType<CardioWorkout>()
            .Sum(cw => cw.DistanceMiles);

        return $"--- Weekly Summary ---\n" +
               $"Workouts this week: {workoutsThisWeek.Count}\n" +
               $"Total cardio miles: {totalCardioMiles}\n" +
               $"Total strength exercises: {totalStrengthExercises}";
    }

    public string GenerateMonthlySummary()
    {
        var workoutsThisMonth = _tracker.GetWorkouts()
            .Where(w => (DateTime.Now - w.Date).TotalDays <= 30).ToList();

        int totalStrengthExercises = workoutsThisMonth
            .OfType<StrengthWorkout>()
            .SelectMany(sw => sw.Exercises)
            .Count();

        double totalCardioMiles = workoutsThisMonth
            .OfType<CardioWorkout>()
            .Sum(cw => cw.DistanceMiles);

        return $"--- Monthly Summary ---\n" +
               $"Workouts this month: {workoutsThisMonth.Count}\n" +
               $"Total cardio miles: {totalCardioMiles}\n" +
               $"Total strength exercises: {totalStrengthExercises}";
    }

    public string GetMotivationalFeedback()
    {
        int totalWorkouts = _tracker.GetWorkouts().Count;
        if (totalWorkouts == 0)
            return "Let's get started today!";
        if (totalWorkouts < 5)
            return "Good start — keep building consistency!";
        if (totalWorkouts < 15)
            return "Great effort! Keep up your momentum!";
        return "Outstanding! You’re crushing your fitness goals!";
    }
}
