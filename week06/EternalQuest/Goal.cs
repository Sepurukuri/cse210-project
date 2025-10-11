using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    public bool IsComplete { get; protected set; }

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        IsComplete = false;
    }

    public abstract int RecordEvent();
    public virtual string GetDetailsString()
    {
        return $"[ {(IsComplete ? "X" : " ")} ] {_name} ({_description})";
    }

    public abstract string GetStringRepresentation();

    public static Goal CreateFromString(string data)
    {
        string[] parts = data.Split('|');
        string type = parts[0];

        return type switch
        {
            "SimpleGoal" => new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])),
            "EternalGoal" => new EternalGoal(parts[1], parts[2], int.Parse(parts[3])),
            "ChecklistGoal" => new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])),
            _ => throw new Exception("Unknown goal type")
        };
    }
}