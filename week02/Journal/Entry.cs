using System;
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public void Display()
    {
        Console.WriteLine($"{_date} - {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
    public override string ToString()
    {
        // Used for saving to a file
        return $"{_date}|{_promptText}|{_entryText}";
    }
    public static Entry FromString(string line)
    {
        string[] parts = line.Split('|');
        Entry e = new Entry();
        e._date = parts[0];
        e._promptText = parts[1];
        e._entryText = parts[2];
        return e;
    }
}