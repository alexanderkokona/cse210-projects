using System;

public abstract class Workout
{
    public string Name { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public int Intensity { get; set; }
    public DateTime Date { get; set; }

    public abstract string GetSummary();
}
