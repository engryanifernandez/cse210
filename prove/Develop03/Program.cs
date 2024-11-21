using System;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("Proverbs", 3, 5, 6);
        var scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding");

        bool continueLoop = true;

        while (continueLoop)
        {
            scripture.Display();
            Console.WriteLine("Enter the number of words to hide or type 'quit' to end:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit" || scripture.AllWordsHidden())
            {
                continueLoop = false;
            }
            else
            {
                if (int.TryParse(input, out int numWords))
                {
                    scripture.HideRandomWords(numWords);
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }


        scripture.Display();
    }
}