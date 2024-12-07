/* 
This C# Program Code is made by Hazel Diane Fernandez for W05 Prove: Developer—Mindfulness
*/

using System;
using System.Threading;

namespace Develop05;

public class ReflectingActivity : Activity
{

    private string[] _prompts = {
        " --- Think of a time when you stood up for someone else. --- ",
        " --- Think of a time when you did something really difficult. --- ",
        " --- Think of a time when you helped someone in need. --- ",
        " --- Think of a time when you did something truly selfless. --- "
    };

    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity(int activityDuration) : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", activityDuration) { }

    public override void Run(int seconds)
    {
        DisplayPrompt();
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        ConsoleKeyInfo input = Console.ReadKey();
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write($"You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        if (input.Key == ConsoleKey.Enter)
        {
            DateTime endTime = DateTime.Now.AddSeconds(seconds);

            while (DateTime.Now < endTime)
            {
                Console.Clear();
                DisplayQuestion();

                for (int i = 5; i > 0; i--)
                {
                    Console.Write(i);
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                }
            }
        }
    }

    private string GetRandomPrompt()
    {
        Random randPrompt = new Random();
        int randomIndex = randPrompt.Next(_prompts.Length);
        return _prompts[randomIndex];
    }

    private string GetRandomQuestion()
    {
        Random randQuestion = new Random();
        int randomIndex = randQuestion.Next(_questions.Length);
        return _questions[randomIndex];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("\n\nConsider the following prompt:\n");
        Console.WriteLine(GetRandomPrompt());
    }

    public void DisplayQuestion()
    {
        Console.Write($"\n> {GetRandomQuestion()} ");
    }
}