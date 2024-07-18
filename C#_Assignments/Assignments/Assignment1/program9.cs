using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class program9
    {
        //generate a fibonacci series till 40
        static void Main()
        {
            int input1 = 0, input2 = 1, next = 0;
            Console.WriteLine("Fibonacci series upto 40 are: ");
            Console.WriteLine(input1);
            Console.WriteLine(input2);
            for (int i = 3; i <= 40; i++)
            {
                next = input1 + input2;
                Console.WriteLine(next);
                input1 = input2;
                input2 = next;
            }
        }
    }
}
