using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class program8
    {
        static void Main()
        {
            //find the factorial of the given number
            Console.WriteLine("Enter the Number: ");
            int Num = int.Parse(Console.ReadLine());
            int fact = 1;
            for (int i = 1; i <=Num; i++)
            {
                fact = fact * i;
                
            }
            Console.WriteLine(fact);
        }
    }
}
