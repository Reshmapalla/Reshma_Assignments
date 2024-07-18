using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    internal class program12
    {
        //numbers divisible by 7 between 200 and 300
        static void Main()
        {
            Console.WriteLine("numbers divisible by 7 between 200 to 300 : ");

            for (int i = 200; i < 300; i++)
            {
                if (i % 7 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
