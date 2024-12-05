using System;
using System.Threading;

namespace Develop05;

public abstract class Activity(string activityName, string description, int activityDuration)
{
    protected string _name = activityName;
    protected string _description = description;
    protected int _duration = activityDuration;

    public void StartActivity()
    {
        Console.Clear();
        DisplayStartingMessage();
    }

    public abstract void Run(int seconds);

    private void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"{_description}\n");
    }

    public int GetActivityDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        int userDuration = Int32.Parse(Console.ReadLine() ?? string.Empty);
        _duration = userDuration;
        return userDuration;
    }

    public void SetActivityDuration(int activityDuration)
    {
        _duration = activityDuration;
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!\n");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} activity.");
        Thread.Sleep(5000);
    }

    public void Loading()
    {
        Console.Clear();
        if (_duration > 0)
        {
            Console.Write("Get ready");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
        }
    }
}