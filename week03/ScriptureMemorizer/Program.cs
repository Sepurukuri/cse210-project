using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements: A library of scriptures
        List<Scripture> library = new List<Scripture>()
        {
            new Scripture(new Reference("2 Nephi", 31, 20),
                "Wherefore, ye must press forward with a steadfastness in Christ, having a perfect brightness of hope, and a love of God and of all men. Wherefore, if ye shall press forward, feasting upon the word of Christ, and endure to the end, behold, thus saith the Father: Ye shall have eternal life."),
            new Scripture(new Reference("1 Nephi", 3, 7),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            new Scripture(new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God."),
            new Scripture(new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be and men are that they might have joy."),
            new Scripture(new Reference("Alma", 5, 26),
                "And now behold, I say unto you, my brethren, if ye have experienced a change of heart, and if ye have felt to sing the song of redeeming love, I would ask, can ye feel so now?")
        };

        // Exceeding requirements: Randomly select a scripture from the library
        Random rand = new Random();
        Scripture scripture = library[rand.Next(library.Count)];

        string input = "";
        while (input != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            input = Console.ReadLine();

            if (input == "")
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden or you chose to quit. Goodbye!");
    }
}