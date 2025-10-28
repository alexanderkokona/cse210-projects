using System;

class Program
{
    static void Main(string[] args)
    {
        User currentUser = new User();

        Console.Write("Enter your name: ");
        currentUser.Name = Console.ReadLine();

        Console.WriteLine($"\nWelcome, {currentUser.Name}! Let's track your fitness journey.");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Add Cardio Workout");
            Console.WriteLine("2. Add Strength Workout");
            Console.WriteLine("3. Add Goal");
            Console.WriteLine("4. View Progress Summary");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    currentUser.LogCardioWorkout();
                    break;
                case "2":
                    currentUser.LogStrengthWorkout();
                    break;
                case "3":
                    currentUser.LogGoal();
                    break;
                case "4":
                    currentUser.ViewProgressSummary();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        Console.WriteLine("\nThank you for using the Fitness Tracker & Planner!");
    }
}
