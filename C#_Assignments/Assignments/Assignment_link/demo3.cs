using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Assignments
{
    public class Order1
    {
        public int OrderID { get; set; }
        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }

    internal class linq4
    {
        static void Main(string[] args)
        {
            List<Order1> order2 = new List<Order1>()
            {
                new Order1() { OrderID = 1, ItemName = "Biryani", OrderDate = new DateTime(2024, 3, 22), Quantity = 3 },
                new Order1() { OrderID = 2, ItemName = "Pizza", OrderDate = new DateTime(2024, 1, 20), Quantity = 7 },
                new Order1() { OrderID = 3, ItemName = "Samosa", OrderDate = new DateTime(2024, 6, 12), Quantity = 2 },
                new Order1() { OrderID = 4, ItemName = "Cake", OrderDate = new DateTime(2024, 4, 2), Quantity = 1 },
                new Order1() { OrderID = 5, ItemName = "Juice", OrderDate = new DateTime(2024, 2, 10), Quantity = 5 },
            };

            var result = from order in order2
                         orderby order.OrderDate.Month descending
                         group order by order.OrderDate.Month;



            foreach (var orders in result)
            {
                Console.WriteLine("Orders in the Month: " + orders.Key);
                foreach (var o in orders)
                {
                    Console.WriteLine($"  OrderID: {o.OrderID}, ItemName: {o.ItemName}, OrderDate: {o.OrderDate}, Quantity: {o.Quantity}");

                }
            }




        }
    }
}