using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Loop to collect numbers until the user enters 0
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            // Only add numbers that are not 0 to the list
            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Check if the list has at least one number
        if (numbers.Count > 0)
        {
            // Compute the sum of the list
            int sum = numbers.Sum();
            Console.WriteLine($"The sum is: {sum}");

            // Compute the average of the list
            double average = numbers.Average();
            Console.WriteLine($"The average is: {average}");

            // Find the maximum number in the list
            int max = numbers.Max();
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenge 1: Find the smallest positive number
            int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
            if (smallestPositive.HasValue)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Stretch Challenge 2: Sort the list and display it
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}