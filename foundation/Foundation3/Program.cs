/* 
This C# Program Code is made by Hazel Diane Fernandez
for W07 Prove: Final Foundation—Inheritance and Polymorphism
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> logs = new();
        Data data = new();

        Running running = new(data.names[0], data.dates[0], data.lengths[0], 5);
        logs.Add(running.GetSummary());
        Cycling cycling = new(data.names[1], data.dates[1], data.lengths[1], 15);
        logs.Add(cycling.GetSummary());
        Swimming swimming = new(data.names[2], data.dates[2], data.lengths[2], 10);
        logs.Add(swimming.GetSummary());
        
        foreach (string log in logs)
        {
            Console.WriteLine($"  - {log}");
        }
    }
}