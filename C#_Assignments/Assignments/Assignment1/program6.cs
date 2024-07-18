using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class program6
    {
        static void Main()
        {
            //Write a program in C# to display temperature in Celsius.Accept the temperature in Fahrenheit.
            Console.Write("Enter The Temperature in Fahrenheit: ");
            double temp=double.Parse(Console.ReadLine());
            double celsius = ((temp - 32) * 5) / 9;
            Console.WriteLine("temperature in celsius: "+celsius);

        }
    }
}
