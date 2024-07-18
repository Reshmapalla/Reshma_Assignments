using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class Program7
    {
        static void Main()
        {
            //Write a program to print the series :0,1,4,9,16,25...625
            Console.Write("enter Number: ");
            int num=int.Parse(Console.ReadLine());
            for (int i = 0; i <=num; i++)
            { 
                int sqr = i * i;
                Console.Write(sqr);
                if (i < num) {
                    Console.Write(",");
                        }
            }

        }
    }
}
