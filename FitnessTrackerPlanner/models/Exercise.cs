using System;

class Exercise
{
    public string Name;
    public int Sets;
    public int Reps;
    public double WeightUsed;

    public double CalculateExerciseVolume() => Sets * Reps * WeightUsed;

    public string GetExerciseDetails()
    {
        return $"{Name} - {Sets}x{Reps} @ {WeightUsed} lbs (Volume: {CalculateExerciseVolume()} lbs)";
    }

    public static Exercise CreateFromInput()
    {
        Exercise e = new Exercise();
        Console.Write("Exercise name: ");
        e.Name = Console.ReadLine();
        Console.Write("Sets: ");
        e.Sets = int.Parse(Console.ReadLine());
        Console.Write("Reps per set: ");
        e.Reps = int.Parse(Console.ReadLine());
        Console.Write("Weight used (lbs): ");
        e.WeightUsed = double.Parse(Console.ReadLine());
        return e;
    }
}
