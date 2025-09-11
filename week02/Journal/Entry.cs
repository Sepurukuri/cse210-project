using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    //Exceeding Requirements
    public int _moodRating;
    public string _tags;

    public void Display()
    {
        Console.WriteLine($"{_date} - {_promptText}");
        Console.WriteLine($"Mood: {_moodRating} | Tags: {_tags}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
    public override string ToString()
    {
        return $"{_date}|{_promptText}|{_entryText}|{_moodRating}|{_tags}";
    }
    public static Entry FromString(string line)
    {
        string[] parts = line.Split('|');
        Entry e = new Entry();
        e._date = parts[0];
        e._promptText = parts[1];
        e._entryText = parts[2];
        e._moodRating = int.Parse(parts[3]);
        e._tags = parts[4];
        return e;
    }
}