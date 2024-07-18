using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class program10
    {
        static void Main()
        {
            //program that asks the user to type an integer N and computes the sum of the cubes
            Console.WriteLine("Enter the number:");
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= num; i++)
            {
                int cube = (int)(Math.Pow(i, 3));
                sum = sum + cube;


            }
            Console.WriteLine(sum);

        }
    }
}
