using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class program18
    {
        //accept two words from the user and find out if they are same.
        static void Main()
        {
            Console.WriteLine("Enter word1: ");
            string s = Console.ReadLine();
            Console.WriteLine("Enter word2: ");
            string s1 = Console.ReadLine();
            if (s1 == s)
            {
                Console.WriteLine("given wors are same");

            }
            else
            {
                Console.WriteLine("given words are not same");
            }
        }
    }
}
