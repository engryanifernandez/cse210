/* 
This C# Program Code is made by Hazel Diane Fernandez for W05 Prove: Developer—Mindfulness

 This program provides a mindfulness app with three different kinds of activities:
 Breathing Activity, Reflection Activity, and Listing Activity.
 Users can select an activity from the menu, input the duration, and engage in the session.
 
 Added Features:
 1. Name Input: 
    - Users are prompted to input their name at the start of the program.
    - This personalization enhances user experience.
 
 2. Activity Logging:
    - The program keeps track of how many activities have been performed in total.
    - Logs the last activity performed and its duration.
    - Logs the date and time of the last session for accountability and tracking.
    - Activity details are saved to a file named "activity_log.txt" for future reference.
 
 Each activity includes:
 - A starting message with the activity name, description, and user-defined duration.
 - A guided session with pauses, animations, and prompts.
 - A concluding message congratulating the user and summarizing the session details.

The program design uses object-oriented principles, such as inheritance, to manage the 
shared functionality of activities through a base class and specific functionality in derived classes.

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