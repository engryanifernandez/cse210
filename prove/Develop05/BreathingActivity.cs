/* 
This C# Program Code is made by Hazel Diane Fernandez for W05 Prove: Developer—Mindfulness
*/

using System;
using System.Threading;

namespace Develop05;

public class BreathingActivity : Activity
{
    private string _breathIn = "Breathe in";
    private string _breathOut = "Now breathe out";
    
    public BreathingActivity(int activityDuration) : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", activityDuration) { }

    public override void Run(int seconds)
    {
        Console.WriteLine();
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write($"{_breathIn} ... ");
            for (int i = 4; i > 0; i--)
            {
                Console.Write($"{i}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.Write($"\n{_breathOut} ... ");
            for (int i = 5; i > 0; i--)
            {
                Console.Write($"{i}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}