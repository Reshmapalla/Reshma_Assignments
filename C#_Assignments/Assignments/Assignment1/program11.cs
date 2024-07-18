using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    //Find the multiplication table of the given number till 20
    internal class program11
    {
        static void Main()
        {
            Console.Write("Enter the number: ");
            int num = int.Parse(Console.ReadLine());
            int i = 1;
            while (i <= 20)
            {
                Console.WriteLine($"{num}*{i}={num * i}");
                i++;
            }
        }
    }
}
