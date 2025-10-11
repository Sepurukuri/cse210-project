using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonus = bonus;

        if (_currentCount >= _targetCount)
        {
            IsComplete = true;
        }
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            _currentCount++;
            if (_currentCount >= _targetCount)
            {
                IsComplete = true;
                Console.WriteLine("🎉 Checklist goal complete! Bonus earned!");
                return _points + _bonus;
            }
            else
            {
                return _points;
            }
        }
        else
        {
            Console.WriteLine("This goal has already been completed!");
            return 0;
        }
    }

    public override string GetDetailsString()
    {
        return $"[ {(IsComplete ? "X" : " ")} ] {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonus}";
    }
}