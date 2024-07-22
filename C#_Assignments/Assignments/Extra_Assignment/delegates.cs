using System;
using System.Collections.Generic;

class delegates
{
    // Define a delegate that takes an integer and returns a boolean
    delegate bool FilterDelegate(int number);

    static void Main()
    {
        // Create and populate the NumList
        List<int> NumList = new List<int> { 1, 3, 6, 9, 12, 15, 18, 20, 21 };

        // Define a method that matches the delegate signature
        bool IsDivisibleBy3(int number)
        {
            return number % 3 == 0;
        }

        // Use the delegate to filter and print numbers
        PrintNumbers(NumList, new FilterDelegate(IsDivisibleBy3));
    }

    // Method that takes a list and a delegate to filter and print numbers
    static void PrintNumbers(List<int> numbers, FilterDelegate filter)
    {
        foreach (int number in numbers)
        {
            if (filter(number))
            {
                Console.WriteLine(number);
            }
        }
    }
}
