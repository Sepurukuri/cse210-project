using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };
    private Random _random = new Random();

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    protected override void RunActivity()
    {
        int duration = GetDurationSeconds();
        Console.WriteLine();
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("You will have a few seconds to think...");
        ShowCountdown(5);
        Console.WriteLine("\nStart listing! Press Enter after each item.");
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        var answers = new List<string>();

        while (DateTime.Now < endTime)
        {
            TimeSpan remaining = endTime - DateTime.Now;
            if (remaining.TotalMilliseconds <= 0) break;

            var readTask = Task.Run(() => Console.ReadLine());
            bool finished = readTask.Wait(remaining);
            if (!finished)
            {
                break;
            }
            string line = readTask.Result;
            if (!string.IsNullOrWhiteSpace(line))
            {
                answers.Add(line.Trim());
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {answers.Count} items:");
        foreach (var item in answers)
        {
            Console.WriteLine($" - {item}");
        }
    }
}