class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by walking you through breathing in and out slowly.";
    }

    public void Perform()
    {
        Start();
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(4000);
            elapsed += 4;
            Console.WriteLine("Breathe out...");
            Thread.Sleep(4000);
            elapsed += 4;
        }
        End();
    }
}
