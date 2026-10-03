using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video(
            "Learning C#",
            "Code Academy",
            600);

        video1.Comments.Add(new Comment("Luz", "This was really helpful!"));
        video1.Comments.Add(new Comment("Maria", "I learned a lot from this."));
        video1.Comments.Add(new Comment("John", "Great explanation!"));

        Video video2 = new Video(
            "How to Make Pasta",
            "Cooking Channel",
            480);

        video2.Comments.Add(new Comment("Ana", "This looks delicious!"));
        video2.Comments.Add(new Comment("Carlos", "I am going to try this."));
        video2.Comments.Add(new Comment("Sofia", "Great recipe!"));

        Video video3 = new Video(
            "Traveling to Peru",
            "Travel World",
            720);

        video3.Comments.Add(new Comment("Emma", "Peru looks beautiful!"));
        video3.Comments.Add(new Comment("David", "I want to visit someday."));
        video3.Comments.Add(new Comment("Liam", "Amazing video!"));

        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}