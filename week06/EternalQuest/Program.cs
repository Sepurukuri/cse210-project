using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("\n=== Eternal Quest Menu ===");
            manager.DisplayScore();
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Show Badges");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    manager.RecordEvent();
                    break;
                case "4":
                    Console.Write("Enter filename: ");
                    manager.SaveGoals(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Enter filename: ");
                    manager.LoadGoals(Console.ReadLine());
                    break;
                case "6":
                    manager.ShowBadges();
                    break;
                case "7":
                    quit = true;
                    Console.WriteLine("Goodbye! Keep chasing your goals!");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter point value: ");
        int pts = int.Parse(Console.ReadLine());

        Goal goal;
        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, desc, pts);
                break;
            case "2":
                goal = new EternalGoal(name, desc, pts);
                break;
            case "3":
                Console.Write("How many times to complete? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points on completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, desc, pts, target, 0, bonus);
                break;
            default:
                Console.WriteLine("Invalid type.");
                return;
        }

        manager.AddGoal(goal);
        Console.WriteLine("Goal created successfully!");
    }
}