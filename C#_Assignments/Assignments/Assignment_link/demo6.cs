using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Assignments
{
    public class Order7
    {
        public int OrderID { get; set; }
        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }


    internal class linq7
    {
        static void Main(string[] args)
        {
            List<Order7> orders = new List<Order7>()
            {
                new Order7() { OrderID = 1, ItemName = "Biryani", OrderDate = new DateTime(2024, 3, 22), Quantity = 1 },
                new Order7() { OrderID = 2, ItemName = "Pizza", OrderDate = new DateTime(2023, 1, 20), Quantity = 7 },
                new Order7() { OrderID = 3, ItemName = "Samosa", OrderDate = new DateTime(2024, 6, 12), Quantity = 2 },
                new Order7() { OrderID = 4, ItemName = "Cake", OrderDate = new DateTime(2023, 4, 2), Quantity = 10 },
                new Order7() { OrderID = 5, ItemName = "Juice", OrderDate = new DateTime(2024, 2, 10), Quantity = 5 },
            };

            /*

             var TQuantity = from order in orders
                          select order.Quantity > 0;

             foreach (var i in TQuantity)
             {
                 Console.WriteLine(i);
             }*/
            ;

            //** 1 **


            bool check = orders.All(order => order.Quantity > 0);

            Console.WriteLine(check ? "ALL ORDERS QUANTITY IS GREATER THAN 0" : "NO,ALL ORDERS QUANTITY IS NOT GREATER THAN 0");

            Console.WriteLine();



            //** 2 ***
            var maxorder = orders.Max(order => order.Quantity);

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Quantity == maxorder)
                {
                    Console.WriteLine($"The Item That Was Ordered In Largest Quantity: {orders[i].ItemName}  Quantity: {orders[i].Quantity}");
                }
            }

            Console.WriteLine();


            //* 3 *


            DateTime condition = new DateTime(2024, 01, 01);
            /*  Console.WriteLine("Orders Placed Before Jan of This Year");

              for (int i = 0; i < orders.Count; i++)
              {
                  if (orders[i].OrderDate < condition)
                  {
                      Console.WriteLine(orders[i].ItemName);
                  }



              }*/

            Console.WriteLine();

            var negativeQuantityOrders = orders.Where(order => order.OrderDate < condition);
            Console.WriteLine("Orders Placed Before Jan of This Year");


            foreach (var order in negativeQuantityOrders)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, ItemName: {order.ItemName}, OrderDate: {order.OrderDate.ToShortDateString()}, Quantity: {order.Quantity}");
            }











        }
    }
}
