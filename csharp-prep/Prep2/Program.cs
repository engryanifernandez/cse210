using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Hello! What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string gradeLetter = "";

        if (grade >= 90)
        {
            gradeLetter = "A";
        }
        else if (grade >= 80) 
        {
            gradeLetter = "B";
        }
        else if (grade >= 70)
        {
            gradeLetter = "C";
        }
        else if (grade >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        int remainder = grade % 10;
        string sign = "";

        if (gradeLetter == "A")
        {
            if (remainder < 3)
            sign = "-";
        }
        else if (gradeLetter == "F")
        {
            sign = "";
        }
        else {
            if (remainder >= 7)
            {
                sign = "+";
            }
            else if (remainder < 3)
            {
                sign = "-";
            }
            else 
            {
                sign = "";
            }
        }

        Console.WriteLine($"Your grade is {gradeLetter}{sign}.");

        if (grade >= 70)
        {
            Console.WriteLine("You Passed!");
        }
        else
        {
            Console.WriteLine("Sorry but you failed!");
        }

    }
}