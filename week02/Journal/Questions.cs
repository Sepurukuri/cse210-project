using System;
using System.Collections.Generic;
public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "What was the most interesting movie I watch today?",
        "What was the best part of the movie?",
        "What did I do to be a better person today?",
        "What was the best part of my day?",
        "One thing i will do better tomorrow?"
    };
    private Random _random = new Random();
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}