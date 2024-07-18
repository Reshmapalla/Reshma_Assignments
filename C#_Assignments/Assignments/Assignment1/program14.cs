using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    //smallest of five numbers accepted from the user
    internal class program14
    {
        static void Main()
        {
            int[] arr = new int[5];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter number: {i}");
                arr[i] = int.Parse(Console.ReadLine());
            }
            int min = Math.Min(Math.Min((Math.Min(arr[0], arr[1])), (Math.Min(arr[2], arr[3]))), arr[4]);
            Console.WriteLine("minimum value in the given numbers is : " + min);
        }

    }
}
