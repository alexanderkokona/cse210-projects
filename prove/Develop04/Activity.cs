using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MindfulnessProgram
{
    abstract class Activity
    {
        protected string Name;
        protected string Description;
        protected int Duration;

        protected static Dictionary<string, int> activityLog = new Dictionary<string, int>();

        public void Start()
        {
            Console.WriteLine($"\n--- {Name} ---");
            Console.WriteLine(Description);
            Console.Write("Enter duration in seconds: ");
            while (!int.TryParse(Console.ReadLine(), out Duration) || Duration <= 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void End()
        {
            Console.WriteLine("\nWell done!");
            Console.WriteLine($"You completed the {Name} activity for {Duration} seconds.");
            ShowSpinner(2);
            LogActivity();
        }

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds * 4; i++)
            {
                Console.Write("/-\\|"[i % 4]);
                Thread.Sleep(250);
                Console.Write("\b");
            }
            Console.WriteLine();
        }

        protected void LogActivity()
        {
            if (activityLog.ContainsKey(Name))
                activityLog[Name]++;
            else
                activityLog[Name] = 1;
        }

        public static void ShowActivityLog()
        {
            if (activityLog.Count == 0) return;
            Console.WriteLine("\n--- Activity Log This Session ---");
            foreach (var entry in activityLog)
                Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
        }

        public abstract void Perform();
    }
}
