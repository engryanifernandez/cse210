using System;

namespace Develop02;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool isRunning = true;
        Console.WriteLine("Welcome to the Journal Program!");

        while (isRunning)
        {
            DisplayMenu();
            Console.WriteLine("\nWhat would you like to do? ");
            string userAnswerChoice = Console.ReadLine();


            switch (userAnswerChoice)
            {
                case "1":
                    journal.AddEntry();
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    journal.LoadFromFile();
                    break;

                case "4":
                    journal.SaveToFile();
                    break;

                case "5":
                    journal.SearchEntries();
                    break;

                case "6":
                    Console.WriteLine("The program has ended. Thank you for using the Journal Program!");
                    isRunning = !isRunning;
                    break;

                default:
                    Console.WriteLine("Incorrect input! Please try again.");
                    break;
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\nPlease select one of the following choices:\n" +
                  "1. Write\n" +
                  "2. Display\n" +
                  "3. Load\n" +
                  "4. Save\n" +
                  "5. Search\n" +
                  "6. Quit");
    }
}