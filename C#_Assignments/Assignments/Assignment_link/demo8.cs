using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignments
{


    public class Order3
    {
        public int OrderID { get; set; }
        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }


    internal class linq9

    {

        static void Main(string[] args)
        {


            // ** 1 **


            int[] A = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

            var EvenNumbers = A.Where(x => x % 2 == 0);

            Console.WriteLine("EVEN NUMBERS IN THE GIVEN ARRAY");

            foreach (var e in EvenNumbers)
            {
                Console.WriteLine(e);
            }

            var Number = EvenNumbers.Count();

            Console.WriteLine("COUNT OF EVEN NUMBERS :" + Number);



            // ** 2 **

            List<Order> orders = new List<Order>()
            {
                new Order() { OrderID = 1, ItemName = "Biryani", OrderDate = new DateTime(2024, 3, 22), Quantity = 3 },
                new Order() { OrderID = 2, ItemName = "Pizza", OrderDate = new DateTime(2024, 1, 20), Quantity = 7 },
                new Order() { OrderID = 3, ItemName = "Samosa", OrderDate = new DateTime(2024, 6, 12), Quantity = 2 },
                new Order() { OrderID = 4, ItemName = "Cake", OrderDate = new DateTime(2024, 4, 2), Quantity = 5 },
                new Order() { OrderID = 5, ItemName = "Juice", OrderDate = new DateTime(2024, 2, 10), Quantity = 5 },
                new Order() { OrderID = 1, ItemName = "Biryani", OrderDate = new DateTime(2024, 3, 22), Quantity = 7 },
                new Order() { OrderID = 2, ItemName = "Pizza", OrderDate = new DateTime(2024, 1, 20), Quantity = 3 },

            };

            // Group by item name and calculate the sum of quantities
            var itemQuantities = from order in orders
                                 group order by order.ItemName into GroupN
                                 select new
                                 {
                                     ItemName = GroupN.Key,
                                     TotalQuantity = GroupN.Sum(order => order.Quantity),

                                 };



            // Display the sum of quantities for each item
            Console.WriteLine("Sum of quantities for each item:");
            foreach (var item in itemQuantities)
            {
                Console.WriteLine($"Item: {item.ItemName}, Total Quantity: {item.TotalQuantity}");
            }

            // Find the item with the maximum total quantity
            var MaxQuantity = itemQuantities.Max(order => order.TotalQuantity);

            Console.WriteLine("Max Quantity :" + MaxQuantity);


            var itemsWithMaxQuantity = itemQuantities
              .Where(item => item.TotalQuantity == MaxQuantity);

            foreach (var item in itemsWithMaxQuantity)
            {
                Console.WriteLine($"Item: {item.ItemName}, Total Quantity: {item.TotalQuantity}");
            }


        }
    }
}