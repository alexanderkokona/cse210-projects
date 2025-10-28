using System;

abstract class Workout
{
    public DateTime Date;
    public int DurationMinutes;
    public int Intensity;

    public abstract double CalculateCaloriesBurned();
    public virtual string GetWorkoutSummary() => "Workout summary not implemented.";
}
