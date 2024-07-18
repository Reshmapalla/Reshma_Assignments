using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Reshmaassignment
{
    internal class Program4
    {
        static void Main()
        {
            //Accept a number from the user and display whether the given number is an even number or odd number
            Console.WriteLine("Enter a number: ");
            int Num = int.Parse(Console.ReadLine());
            if (Num % 2 == 0) {
                Console.WriteLine("Given number is Even Number");
            } else
            { 
            Console.WriteLine("Given Numnber is Odd Number");
            }
        }
    }
}
