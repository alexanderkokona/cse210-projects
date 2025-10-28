using System;
using System.Collections.Generic;

class StrengthWorkout : Workout
{
    public List<Exercise> Exercises = new List<Exercise>();

    public override double CalculateCaloriesBurned()
    {
        return Exercises.Count * 50; // simple estimate
    }

    public override string GetWorkoutSummary()
    {
        return $"Strength Workout on {Date.ToShortDateString()} | {Exercises.Count} Exercises";
    }

    public void AddExercise(Exercise exercise)
    {
        Exercises.Add(exercise);
    }
}
