using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class shapes
    {
        int x;
        int y;
        double PI;
        void Area(long x)
        {
            Console.WriteLine("Area of Square: " + x * x);
        }
        void Area(int x, int y)
        {
            Console.WriteLine("Area of rectangle: " + x * y);
        }
        void Area(long x, int y)
        {
            Console.WriteLine("Area of triangle: " + 0.5 * x * y);
        }
        void Area(int x)
        {
            Console.WriteLine("Area of Circle: " + Math.PI * x * x);
        }
        static void Main()
        {
            shapes s = new shapes();
            s.Area(30);
            s.Area(20, 20);
            s.Area(34, 34);
            s.Area(20);
        }
    }


}
