using System;
using System.Collections.Generic;
using System.Linq;

namespace MindfulnessProgram
{
    class ReflectionActivity : Activity
    {
        private string[] Prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private string[] Questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience for the future?",
            "What did you learn about yourself?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
        {
            Name = "Reflection Activity";
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
        }

        public override void Perform()
        {
            Start();
            Random rand = new Random();
            Console.WriteLine("\n" + Prompts[rand.Next(Prompts.Length)]);
            int elapsed = 0;
            List<string> shuffledQuestions = Questions.OrderBy(x => rand.Next()).ToList();
            int questionIndex = 0;

            while (elapsed < Duration)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string question = shuffledQuestions[questionIndex % shuffledQuestions.Count];
                Console.WriteLine(question);
                ShowSpinner(3);
                elapsed += 3;
                questionIndex++;
            }
            Console.ResetColor();
            End();
        }
    }
}
