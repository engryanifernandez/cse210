/* 
This C# Program Code is made by Hazel Diane Fernandez
for W04 Prove: Foundation Program #1—Abstraction
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        Video video1 = new Video("Life of a Civil Engineer", "Yani Fernandez", 420);
        Video video2 = new Video("Top 5 Guns for Beginners", "Caleb Anderson", 300);
        Video video3 = new Video("Balancing Life as a Single Mom", "Yani Fernandez", 360);

        video1.AddComment(new Comment("Ashton", "Mom, you're so cool! I want to build like you someday!"));
        video1.AddComment(new Comment("Hailey", "I love watching you work, Mommy!"));
        video1.AddComment(new Comment("Caleb", "You amaze me every day with your hard work, Mahal!"));

        video2.AddComment(new Comment("John", "Great list, Caleb! The Glock is a classic."));
        video2.AddComment(new Comment("Mike", "I've been thinking of getting the Sig Sauer. Thanks for the tips!"));
        video2.AddComment(new Comment("Sarah", "I love how you explain things so clearly!"));

        video3.AddComment(new Comment("Caleb", "You're a superhero, Mahal. I'm so proud of you!"));
        video3.AddComment(new Comment("Ashton", "Mom, you always make time for us. You're the best!"));
        video3.AddComment(new Comment("Hailey", "I love our family time, Mommy!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            video.DisplayDetails();
            Console.WriteLine();
        }
    }
}
