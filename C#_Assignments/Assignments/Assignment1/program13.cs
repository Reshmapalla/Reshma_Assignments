using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    //largest of 3 given numbers
    internal class program13
    {
        static void Main()
        {
            int a, b, c;
            Console.Write("Enter the first number:");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number:");
            b = int.Parse(Console.ReadLine());
            Console.Write("Enter the third number:");
            c = int.Parse(Console.ReadLine());
            if (a > b && a > c)
            {
                Console.WriteLine($"{a} is bigger");
            }
            else if (b > c)
            {
                Console.WriteLine($"{b} is bigger");
            }
            else
            {
                Console.WriteLine($"{c} is bigger");
            }
        }
    }
}
