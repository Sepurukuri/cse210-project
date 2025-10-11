using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private List<string> _badges = new List<string>();

    private void UpdateLevel()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"\n🎉 Level Up! You are now Level {_level}! 🎉");
        }
    }

    private void CheckBadges()
    {
        if (_score >= 5000 && !_badges.Contains("Diamond Achiever"))
        {
            _badges.Add("Diamond Achiever");
            Console.WriteLine("🏆 New Badge Unlocked: Diamond Achiever!");
        }

        int completed = _goals.FindAll(g => g.IsComplete).Count;
        if (completed >= 5 && !_badges.Contains("Goal Crusher"))
        {
            _badges.Add("Goal Crusher");
            Console.WriteLine("🏅 Badge Unlocked: Goal Crusher!");
        }

        if (_level >= 10 && !_badges.Contains("Legendary Rank"))
        {
            _badges.Add("Legendary Rank");
            Console.WriteLine("🌟 Achievement Unlocked: Legendary Rank!");
        }
    }

    public string GetTitle()
    {
        if (_level < 3) return "Apprentice Seeker";
        else if (_level < 6) return "Faithful Warrior";
        else if (_level < 10) return "Master of Goals";
        else return "Legendary Achiever";
    }

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Add one!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        ListGoals();
        Console.Write("\nEnter the number of the goal you completed: ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal g = _goals[idx - 1];
        int earned = g.RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points! Total: {_score} pts.");

        UpdateLevel();
        CheckBadges();
    }

    public void ShowBadges()
    {
        Console.WriteLine("\nYour Badges:");
        if (_badges.Count == 0)
            Console.WriteLine("No badges yet — keep going!");
        else
            foreach (var b in _badges) Console.WriteLine($"- {b}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            writer.WriteLine(string.Join(",", _badges));
            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            _level = int.Parse(reader.ReadLine());
            string badgeLine = reader.ReadLine();
            _badges = new List<string>(badgeLine.Split(',', StringSplitOptions.RemoveEmptyEntries));

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Goal g = Goal.CreateFromString(line);
                _goals.Add(g);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\n⭐ Score: {_score} | Level {_level} ({GetTitle()})");
    }
}