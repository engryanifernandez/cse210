using System;
using System.Collections.Generic;
using System.Threading;

namespace Develop05;

public class ListingActivity(int activityDuration) : Activity("Listing",
    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
    activityDuration)
{
    private string[] _prompts = {
        " --- Who are people that you appreciate? --- ",
        " --- What are personal strengths of yours? --- ",
        " --- Who are people that you have helped this week? --- ",
        " --- When have you felt the Holy Ghost this month? --- ",
        " --- Who are some of your personal heroes? --- "
    };

    public override void Run(int time)
    {
        DisplayPrompt();
        Console.Write($"You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        DateTime endTime = DateTime.Now.AddSeconds(time);
        while (DateTime.Now < endTime)
        {
            GetListFromUser();
        }
    }

    private string GetRandomPrompt()
    {
        Random randPrompt = new Random();
        int randomIndex = randPrompt.Next(_prompts.Length);
        return _prompts[randomIndex];
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        Console.Write("\n> ");
        string userInput;
        userInput = Console.ReadLine();
        items.Add(userInput);

        return items;
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("\n\nList as many responses you can to the following prompt:\n");
        Console.WriteLine(GetRandomPrompt());
    }
}