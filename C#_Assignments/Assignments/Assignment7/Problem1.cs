using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    internal class Problem1
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter 10 Numbers:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"enter number{i + 1}");
                int Num = int.Parse(Console.ReadLine());
                numbers.Add(Num);
            }
            numbers.Sort();
            Console.WriteLine("sorted Numbres:");
            foreach (var k in numbers)
            {
                Console.Write(k + " ");
            }
        }
    }
}
