using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    public void Start()
    {
        Console.Clear();
        ShowStartingMessage();
        SetDurationFromUser();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        RunActivity();
        ShowEndingMessage();
    }
    protected abstract void RunActivity();

    private void ShowStartingMessage()
    {
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    private void ShowEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {_durationSeconds} seconds.");
        ShowSpinner(3);
    }

    private void SetDurationFromUser()
    {
        int seconds = 0;
        while (true)
        {
            Console.Write("Enter duration in seconds: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out seconds) && seconds > 0)
            {
                _durationSeconds = seconds;
                break;
            }
            Console.WriteLine("Please enter a positive integer for seconds.");
        }
    }
    protected int GetDurationSeconds()
    {
        return _durationSeconds;
    }
    protected void ShowSpinner(int seconds)
    {
        char[] spinner = new char[] { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write('\b');
            i++;
        }
    }
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // erase digit / char
        }
    }
}