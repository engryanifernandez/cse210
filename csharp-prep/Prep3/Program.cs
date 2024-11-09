using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "";

        do
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);

            int guess = 0;
            int attempt = 0;


            while (guess != number)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempt++;

                if (number > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (number < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guess it!");
                    Console.WriteLine($"You made {attempt} guesses.");
                    Console.Write("Do you want to play again? (yes/no)" );
                    playAgain = Console.ReadLine()?.ToLower();
                }
            } 
        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}