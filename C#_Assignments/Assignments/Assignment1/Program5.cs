using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class Program5
    {
        static void Main()
        {
            //Write a program in C# to find the total number of odd and even numbers accepted from the user.
            int[] input = new int[10];
            Console.WriteLine("ENter Input");
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"input[{i}]");
                input[i] = Convert.ToInt32(Console.ReadLine());
            }
            int countofeven = 0, countofodd = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    countofeven++;
                }
                else
                {
                    countofodd++;
                }

            }
            Console.WriteLine("Total no of Even Numbers: " + countofeven);
            Console.WriteLine("Total no of odd Numbers: " + countofodd);
                
            


        }
    }
}
