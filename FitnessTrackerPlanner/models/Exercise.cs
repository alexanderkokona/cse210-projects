public class Exercise
{
    public string Name { get; set; } = string.Empty;
    public int Sets { get; set; }
    public int Reps { get; set; }
    public double Weight { get; set; } // lbs

    public double CalculateVolume() => Sets * Reps * Weight;
}
