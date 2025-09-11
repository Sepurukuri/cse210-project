using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToString());
            }
        }
    }
    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Entry entry = Entry.FromString(line);
            _entries.Add(entry);
        }
    }
    public void DisplayRandomEntry()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to show.");
            return;
        }

        Random rand = new Random();
        int index = rand.Next(_entries.Count);
        Console.WriteLine("Random past entry:\n");
        _entries[index].Display();
    }
}