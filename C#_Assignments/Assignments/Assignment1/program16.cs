using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    //accept the word from the user and display the length of it.
    internal class program16
    {
        static void Main()
        {
            Console.WriteLine("Enter word: ");
            string s = Console.ReadLine();
            int len = s.Length;

            Console.WriteLine($"Length of given word is :{len}");
        }
    }
}
