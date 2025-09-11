using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;

                theJournal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
                Console.WriteLine("Journal saved.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded.");
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice, try again.");
            }
        }
    }
}