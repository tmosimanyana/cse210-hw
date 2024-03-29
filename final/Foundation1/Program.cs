using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");
       List<Video> videos = new List<Video>();

        // Creating videos
        Video video1 = new Video("Title 1", "Author 1", 120);
        video1.AddComment("User1", "Great video!");
        video1.AddComment("User2", "Nice content!");

        Video video2 = new Video("Title 2", "Author 2", 180);
        video2.AddComment("User3", "Interesting topic!");
        video2.AddComment("User4", "I learned a lot!");

        Video video3 = new Video("Title 3", "Author 3", 150);
        video3.AddComment("User5", "Well explained!");
        video3.AddComment("User6", "Keep up the good work!");

        // Adding videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.UserName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string userName, string text)
    {
        Comments.Add(new Comment(userName, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string UserName { get; }
    public string Text { get; }

    public Comment(string userName, string text)
    {
        UserName = userName;
        Text = text;
    }
} 
    
