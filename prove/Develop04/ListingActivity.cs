using System;

namespace MindfulnessProgram
{
    class ListingActivity : Activity
    {
        private string[] Prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are some of your personal heroes?",
            "When have you felt gratitude this week?"
        };

        public ListingActivity()
        {
            Name = "Listing Activity";
            Description = "This activity will help you reflect on the good things in your life by listing items in a certain area.";
        }

        public override void Perform()
        {
            Start();
            Random rand = new Random();
            Console.WriteLine("\n" + Prompts[rand.Next(Prompts.Length)]);
            Console.WriteLine("Start listing items (press Enter after each):");

            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            int count = 0;
            while (DateTime.Now < endTime)
            {
                if (!string.IsNullOrWhiteSpace(Console.ReadLine())) count++;
            }

            Console.WriteLine($"\nYou listed {count} items!");
            End();
        }
    }
}
