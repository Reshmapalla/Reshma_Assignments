using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{

    internal class Program3
    {
        public double pi = 3.14;
        public void Rect(int l, int b)
        {
            int AreaofRect = l * b;
            Console.WriteLine($"Area Of Rectagle: {AreaofRect}");

        }
        public void Triangle(int l, int b)
        {
            Console.WriteLine("Area Of Triangle:" + (0.5 * l * b));
        }
        public void Circle(int r)
        {
            Console.WriteLine("Area Of Circle:" + (2 * pi * r));
        }
        public void Square(double l)
        {
            Console.WriteLine("Area of the square" +(l*l));
        }

        static void Main()
        {
            Program3 obj = new Program3();
            obj.Rect(2, 3);
            obj.Circle(6);
            obj.Triangle(2, 5);
            obj.Square(5);
        }
    }
}
