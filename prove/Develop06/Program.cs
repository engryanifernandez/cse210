using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}

/* 
Explanation of Exceeding Requirements:

1. Added Gamification:
   - Introduced a leveling-up system where players earn levels after accumulating a certain number of points.
   - Players are awarded bonus points when they level up, making the program more engaging and rewarding.

2. Added a New Goal Type - Negative Goals:
   - Negative Goals allow the user to lose points for undesirable behaviors (e.g., bad habits).
   - This type of goal is useful for users who want to track and reduce negative behaviors.

These additions enhance the functionality of the program, adding a more creative and engaging experience for users.
*/
