using System;
using System.Collections.Generic;

public class StrengthWorkout : Workout
{
    public List<Exercise> Exercises { get; set; } = new();

    public void AddExercise(Exercise exercise)
    {
        Exercises.Add(exercise);
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} - Strength: {Name}, Exercises: {Exercises.Count}, Duration: {DurationMinutes} mins, Intensity: {Intensity}";
    }
}
