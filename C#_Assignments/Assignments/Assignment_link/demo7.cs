using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Assignments
{
    public class Order8
    {
        public int OrderID { get; set; }
        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }


    internal class linq8
    {
        static void Main(string[] args)
        {
            List<Order8> orders = new List<Order8>()
            {
                new Order8() { OrderID = 1, ItemName = "Biryani", OrderDate = new DateTime(2024, 3, 22), Quantity = 11 },
                new Order8() { OrderID = 2, ItemName = "Pizza", OrderDate = new DateTime(2023, 1, 20), Quantity = 9 },
                new Order8() { OrderID = 3, ItemName = "Samosa", OrderDate = new DateTime(2024, 6, 12), Quantity = 0 },
                new Order8() { OrderID = 4, ItemName = "Cake", OrderDate = new DateTime(2023, 4, 2), Quantity = 11 },
                new Order8() { OrderID = 5, ItemName = "Juice", OrderDate = new DateTime(2024, 2, 10), Quantity = 9 },
            };

            // USING COUNT METHOD INSTEAD OF ALL TO FIND IS ALL ORDERS QUANTITY IS GREATER THAN ZERO


            bool UsingCount = orders.Count(order => order.Quantity <= 0) == 0;

            Console.WriteLine(UsingCount ? "ALL ORDERS QUANTITY IS GREATER THAN 0" : "NO,ALL ORDERS QUANTITY IS NOT GREATER THAN 0");


            //  USING COUNT  TO FIND LARGEST QUANTITY ORDER

            var maxorder = orders.Max(order => order.Quantity);


            int countOfMaxQuantityOrders = orders.Count(order => order.Quantity == maxorder);

            Console.WriteLine($"MAX QUANTITY : {maxorder},  COUNT: {countOfMaxQuantityOrders}");

            var maxitem = orders.Where(order => order.Quantity == maxorder).ToList();


            foreach (var order in maxitem)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, ItemName: {order.ItemName}, OrderDate: {order.OrderDate.ToShortDateString()}, Quantity: {order.Quantity}");
            }

            //USING COUNT 

            int hasOrdersBeforeJanuary = orders.Count(order => order.OrderDate < new DateTime(DateTime.Now.Year, 1, 1));

            Console.WriteLine(hasOrdersBeforeJanuary);

        }
    }
}