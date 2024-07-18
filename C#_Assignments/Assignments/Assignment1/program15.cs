using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reshmaassignment
{
    /*to accept ten marks and display the following
     1.Total
     2.Average
    3.Minimim marks
    4.Maximum marks
    5.Display marks in Ascending order
    6.Display marks in Descending order
     */
    internal class program15
    {
        static void Main()
        {

            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter number{i}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            //Total
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine(sum);
            //Average
            int sum1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum1 += arr[i];
            }
            double avg = (double)sum1 / arr.Length;
            Console.WriteLine(avg);
            //Minimum marks
            int minMarks = arr.Min();
            Console.WriteLine($"Minimum marks:{minMarks}");
            //Maximum marks
            int maxMarks = arr.Max();
            Console.WriteLine($"Maximum marks:{maxMarks}");

            //Display marks in Ascending order
            int[] ascendingMarks = (int[])arr.Clone();
            Array.Sort(ascendingMarks);
            Console.WriteLine("Marks in ascending order: " + string.Join(", ", ascendingMarks));

            //Display marks in descending order
            int[] descendingMarks = (int[])arr.Clone();
            Array.Sort(descendingMarks);
            Array.Reverse(descendingMarks);
            Console.WriteLine("Marks in ascending order: " + string.Join(", ", descendingMarks));
        }
    }
    
}
