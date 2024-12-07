/* 
This C# Program Code is made by Hazel Diane Fernandez for W05 Prove: Developer—Mindfulness
*/

using System;
using System.Threading;

namespace Develop05;

static class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            DisplayMenu();
            Console.Write("Select a choice from the menu: ");

            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Activity breathing = new BreathingActivity(0);
                    ExecuteActivity(breathing);
                    break;

                case "2":
                    Activity reflecting = new ReflectingActivity(0);
                    ExecuteActivity(reflecting);
                    break;

                case "3":
                    Activity listing = new ListingActivity(0);
                    ExecuteActivity(listing);
                    break;

                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program! See you next time!");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select an activity (1-4).");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    private static void ExecuteActivity(Activity activity)
    {

        activity.StartActivity();
        int seconds = activity.GetActivityDuration();
        activity.Loading();
        activity.Run(seconds);
        activity.DisplayEndingMessage();
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\nMenu Option:\n 1. Breathing Activity\n 2. Reflection Activity\n" +
                          " 3. Listing Activity\n 4. Quit");
    }
}