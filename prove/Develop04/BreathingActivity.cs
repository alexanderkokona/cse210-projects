using System;
using System.Threading;

namespace MindfulnessProgram
{
    class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            Name = "Breathing Activity";
            Description = "This activity will help you relax by walking you through breathing in and out slowly.";
        }

        public override void Perform()
        {
            Start();
            int elapsed = 0;
            while (elapsed < Duration)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                AnimateBreath("Breathe in", 4);
                elapsed += 4;
                Console.ForegroundColor = ConsoleColor.Green;
                AnimateBreath("Breathe out", 4);
                elapsed += 4;
            }
            Console.ResetColor();
            End();
        }

        private void AnimateBreath(string message, int seconds)
        {
            Console.Write(message + " ");
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
