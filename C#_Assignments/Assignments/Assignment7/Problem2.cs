using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    // Write an List that will hold the names of all students and display them in descending order. 

    internal class Problem2
    {
        static void Main()
        {
            List<string> list = new List<string>
            {
                "seetha",
                "geetha",
                "poojitha",
                "rama",
                "john",
                "emily"
            };
            list.Sort();
            list.Reverse();
            Console.WriteLine("Students name in descending order: ");
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

        }
    }
}