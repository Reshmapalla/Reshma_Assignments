using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Building
    {
        public string Type;
        public string Capacity;
        public string Dimension;
        public string FloorNumber;
        public string AdditionalInfo;
        public string DateOfCompletion;
        public string LandDimension;
        public Building(string Type, string Capacity, string Dimension, string DateOfCompletion,string AdditionalInfo)
        {
            this.Type = Type;
            this.Capacity = Capacity;
           
            this.AdditionalInfo = AdditionalInfo;
            this.DateOfCompletion = DateOfCompletion;

            this.Dimension = Dimension;
            
           
            

           

        }
        public void Display()
        {
            
            if (Type.ToLower() == "flat")
            {
                this.FloorNumber = AdditionalInfo;
                this.LandDimension = null;

            }
            else if (Type.ToLower() == "villa")
            {
                this.LandDimension = AdditionalInfo;
                this.FloorNumber = null;
            }
            else
            {
                Console.WriteLine("type should be flat or villa");
            }
            Console.WriteLine($"Type: {this.Type} Capacity:{this.Capacity}\n Dimension: {this.Dimension}\n DateOfCompletion: {DateOfCompletion}\n FloorNumber: {FloorNumber}\nLandDImension:{LandDimension}");

        }

        static void Main()
        {
            Building obj = new Building("flat","2bhk","599*5888","2023/04/09","1" );
            Building obj1 = new Building("villa", "2bhk", "599*5888", "2023/04/09", "800*67");
            obj.Display();
            obj1.Display();
            
        }



    }
}
