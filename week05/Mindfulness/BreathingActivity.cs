using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    protected override void RunActivity()
    {
        int totalSeconds = GetDurationSeconds();
        int elapsed = 0;
        int inhaleSeconds = 4;
        int exhaleSeconds = 4;

        while (elapsed < totalSeconds)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountdown(Math.Min(inhaleSeconds, Math.Max(1, totalSeconds - elapsed)));
            elapsed += inhaleSeconds;
            if (elapsed >= totalSeconds) break;

            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(Math.Min(exhaleSeconds, Math.Max(1, totalSeconds - elapsed)));
            elapsed += exhaleSeconds;
        }
    }
}