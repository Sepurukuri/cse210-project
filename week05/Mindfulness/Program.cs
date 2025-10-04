using System;

public class Program
{
    public static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("----------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            // Additonal required activity
            Console.WriteLine("4. Visualization Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var breathing = new BreathingActivity();
                    breathing.Start();
                    PauseBeforeContinue();
                    break;
                case "2":
                    var reflection = new ReflectionActivity();
                    reflection.Start();
                    PauseBeforeContinue();
                    break;
                case "3":
                    var listing = new ListingActivity();
                    listing.Start();
                    PauseBeforeContinue();
                    break;
                case "4":
                    var visualization = new VisualizationActivity();
                    visualization.Start();
                    PauseBeforeContinue();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void PauseBeforeContinue()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}