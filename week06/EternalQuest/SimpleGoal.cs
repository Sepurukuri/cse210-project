using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        IsComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return _points;
        }
        else
        {
            Console.WriteLine("This goal has already been completed!");
            return 0;
        }
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{IsComplete}";
    }
}