using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class program19
    {
        //accept word from the user and check weather it is a palindrome or not
        static void Main()
        {
            Console.WriteLine("Enter the word: ");
            string s = Console.ReadLine();
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            string s1 = new string(chars);
            Console.WriteLine(s1);
            if (s1 == s)
            {
                Console.WriteLine("palindrome");

            }
            else
            {
                Console.WriteLine("not a palindrome");
            }
        }
    }
}
