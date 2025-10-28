using System;

public class CardioWorkout : Workout
{
    public double DistanceMiles { get; set; }
    public double Pace { get; set; } // minutes per mile

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} - Cardio: {Name}, Duration: {DurationMinutes} mins, Distance: {DistanceMiles} mi, Intensity: {Intensity}";
    }
}
