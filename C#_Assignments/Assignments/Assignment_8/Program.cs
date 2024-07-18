
using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Assignment_8
{
    internal class Program
    {


        static void Main(string[] args)
        {

            string[] Names = new string[5];
            for (int i = 0; i < Names.Length; i++)
            {
                Console.WriteLine($"enter {i + 1} user");
                Names[i] = Console.ReadLine();
            }
            string filePath = "d:/storingintofile.txt";



            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var k in Names)
                {
                    writer.WriteLine(k);

                }
            }




        }

    }
}










