using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class program2
    {
        static void Main()
        {
            /*Write a program in C# to accept the name of the user as a Command Line arguement and greet the user as :"Hi! username
            Welcome to the world of C#
            */
            Console.WriteLine("enter your Name :");
            string Name = Console.ReadLine();
            Console.WriteLine("Hi!"+ Name);
            Console.WriteLine("Welcome to the world of C#");

        }
    }
}
