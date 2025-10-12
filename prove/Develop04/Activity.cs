using System;
using System.Threading;

class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public void Start()
    {
        Console.WriteLine($"Starting {Name}");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You completed the {Name} activity for {Duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(500);
            Console.Write("\b-");
            Thread.Sleep(500);
            Console.Write("\b\\");
            Thread.Sleep(500);
            Console.Write("\b|");
            Thread.Sleep(500);
            Console.Write("\b");
        }
        Console.WriteLine();
    }
}
