using System;

class Goal
{
    public string Description;
    public string GoalType;
    public double TargetValue;
    public double CurrentValue;
    public bool IsCompleted;

    public void UpdateProgress(double amount)
    {
        CurrentValue += amount;
        IsCompleted = CheckIfCompleted();
    }

    public bool CheckIfCompleted()
    {
        return CurrentValue >= TargetValue;
    }

    public string GetGoalSummary()
    {
        return $"{Description} - {CurrentValue}/{TargetValue} ({(IsCompleted ? "Completed" : "In Progress")})";
    }

    public static Goal CreateFromInput()
    {
        Goal g = new Goal();
        Console.Write("Goal description: ");
        g.Description = Console.ReadLine();
        Console.Write("Goal type (Distance, Weight, Time, etc.): ");
        g.GoalType = Console.ReadLine();
        Console.Write("Target value: ");
        g.TargetValue = double.Parse(Console.ReadLine());
        g.CurrentValue = 0;
        g.IsCompleted = false;
        return g;
    }
}
