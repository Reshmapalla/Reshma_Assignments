using System;

class demo2
{
    static void Main()
    {
        // Example usage of the SUM method
        int result = SUM(1, 2, 3, 4, 5);
        Console.WriteLine("The sum is: " + result);
    }

    // Define the SUM method that takes a variable number of integer arguments
    static int SUM(params int[] numbers)
    {
        int sum = 0;

        // Iterate over each number and add it to the sum
        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }
}