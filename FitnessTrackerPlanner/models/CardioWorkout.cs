using System;

class CardioWorkout : Workout
{
    public double DistanceMiles;
    public double Pace;

    public override double CalculateCaloriesBurned()
    {
        return DurationMinutes * 8; // rough estimate
    }

    public override string GetWorkoutSummary()
    {
        return $"Cardio Workout on {Date.ToShortDateString()} | Duration: {DurationMinutes} mins | Distance: {DistanceMiles} mi";
    }
}
