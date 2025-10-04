using System;
using System.Collections.Generic;
 // Additonal required activity
public class VisualizationActivity : Activity
{
    private List<string> _visualizationPrompts = new List<string>
    {
        "Imagine yourself sitting peacefully beside a calm lake.",
        "Picture yourself walking through a quiet forest trail.",
        "Visualize yourself lying on a warm beach with gentle waves.",
        "Imagine floating in the sky surrounded by soft white clouds."
    };

    private List<string> _sensoryPrompts = new List<string>
    {
        "What do you see around you?",
        "What sounds can you hear?",
        "What do you feel against your skin?",
        "What scents can you smell?",
        "What emotions do you feel in this peaceful place?"
    };

    private Random _random = new Random();

    public VisualizationActivity()
        : base("Visualization Activity",
               "This activity will help you relax by guiding you through a peaceful mental visualization. Focus on your senses and immerse yourself in the calm environment you imagine.")
    { }

    protected override void RunActivity()
    {
        int duration = GetDurationSeconds();
        string scene = _visualizationPrompts[_random.Next(_visualizationPrompts.Count)];

        Console.WriteLine();
        Console.WriteLine("Close your eyes and visualize the following scene:");
        Console.WriteLine($"--- {scene} ---");
        Console.WriteLine("Take a few seconds to picture it clearly in your mind...");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string sensePrompt = _sensoryPrompts[_random.Next(_sensoryPrompts.Count)];
            Console.WriteLine();
            Console.WriteLine($"→ {sensePrompt}");
            ShowSpinner(6);
        }
    }
}