using System.ComponentModel;
using System.Globalization;
using System.Transactions;

//1. Accept 10 numbers and sort the data in ascending order and display it
namespace Assignment_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter 10 Numbers:");
            for ( int i = 0; i < 10; i++)
            {
                Console.WriteLine($"enter number{i+1}");
                int Num =int.Parse( Console.ReadLine());
                numbers.Add(Num);
            }
            numbers.Sort();
            Console.WriteLine("sorted Numbres:");
            foreach (var k in numbers)
            {
                Console.Write(k+" ");
            }
        }
    }
}