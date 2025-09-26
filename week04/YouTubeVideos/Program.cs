using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine($"  {CommenterName}: {Text}");
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumComments()
    {
        return Comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumComments()}");
        Console.WriteLine("Comments:");
        foreach (Comment c in Comments)
        {
            c.Display();
        }
    }
}
class Program
{
    static void Main()
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