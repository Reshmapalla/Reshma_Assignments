using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class Program3
    {
        static void Main()
        {
            //Write a program in C# to accept two numbers as command line arguement and display all the numbers between the given two numbers
            Console.WriteLine("enter first number: ");
            int num1=int.Parse(Console.ReadLine());
            Console.WriteLine("enter second number: ");
            int num2= int.Parse(Console.ReadLine());
            for (int i = num1+1; i < num2; i++)
            {
                Console.WriteLine(i);

            }


        }


    }
}
