using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        Video v1 = new Video("Abstraction in C#", "Tech Guru", 600);
        Video v2 = new Video("OOP Basics", "Code Master", 720);
        Video v3 = new Video("Encapsulation Explained", "Dev Coach", 540);

        v1.AddComment(new Comment("Alice", "Great explanation!"));
        v1.AddComment(new Comment("Bob", "Helped me a lot, thanks."));
        v1.AddComment(new Comment("Charlie", "Please do one on inheritance."));

        v2.AddComment(new Comment("David", "Clear and concise."));
        v2.AddComment(new Comment("Ella", "Love your teaching style."));
        v2.AddComment(new Comment("Frank", "Could you cover polymorphism next?"));

        v3.AddComment(new Comment("Grace", "Super helpful!"));
        v3.AddComment(new Comment("Hannah", "This made encapsulation easy to understand."));
        v3.AddComment(new Comment("Ivan", "Looking forward to more OOP videos."));

        List<Video> videos = new List<Video> { v1, v2, v3 };

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}