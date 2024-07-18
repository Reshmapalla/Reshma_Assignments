using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_8
{
    internal class Car
    {
       public  string CarModel { get; set; }
        public string YearofMaking { get; set; }

        public void Write(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Car Details");
                sw.Write($"CarModel:{CarModel}");
                sw.Write($"YearofMaking:{YearofMaking}");
            }
        }
        public void Read(String path)
        {


            using (StreamReader sr = new StreamReader(path))
            {
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

        }

    
    static void Main()
        {
            Car car = new Car();
            Console.WriteLine("enter Car Model:");
            car.CarModel = Console.ReadLine();
            Console.WriteLine("enter Year Of making:");
            car.YearofMaking= Console.ReadLine();
            Console.WriteLine("Enter path to store car details");
            string path = Console.ReadLine();
            car.Write(path);
            car.Read(path);



        }
    }
}
