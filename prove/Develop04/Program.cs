class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Quit");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    new BreathingActivity().Perform();
                    break;
                case "2":
                    new ReflectionActivity().Perform();
                    break;
                case "3":
                    new ListingActivity().Perform();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
