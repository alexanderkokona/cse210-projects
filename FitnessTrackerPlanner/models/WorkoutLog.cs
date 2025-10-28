using System;
using System.Collections.Generic;

class WorkoutLog
{
    public List<Workout> Workouts = new List<Workout>();

    public void AddWorkout(Workout workout)
    {
        Workouts.Add(workout);
    }

    public double GetTotalCaloriesBurned()
    {
        double total = 0;
        foreach (var w in Workouts)
        {
            total += w.CalculateCaloriesBurned();
        }
        return total;
    }

    public void DisplayAllWorkouts()
    {
        if (Workouts.Count == 0)
        {
            Console.WriteLine("No workouts logged yet.");
            return;
        }

        foreach (var w in Workouts)
        {
            Console.WriteLine(w.GetWorkoutSummary());
        }
    }
}
