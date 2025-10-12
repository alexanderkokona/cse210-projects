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
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection Activity";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public void Perform()
    {
        Start();
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Length)]);
        int elapsed = 0;
        while (elapsed < Duration)
        {
            string question = Questions[rand.Next(Questions.Length)];
            Console.WriteLine(question);
            Thread.Sleep(4000);
            elapsed += 4;
        }
        End();
    }
}
