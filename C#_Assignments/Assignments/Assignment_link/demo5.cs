﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Assignments
{
    public class Order6
    {
        public int OrderID { get; set; }
        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }

    public class Item6
    {
        public string ItemName { get; set; }
        public int Price { get; set; }
    }

    internal class linq6
    {
        static void Main(string[] args)
        {
            List<Order6> orders = new List<Order6>()
            {
                new Order6() { OrderID = 1, ItemName = "Biryani", OrderDate = new DateTime(2024, 3, 22), Quantity = 3 },
                new Order6() { OrderID = 2, ItemName = "Pizza", OrderDate = new DateTime(2024, 1, 20), Quantity = 7 },
                new Order6() { OrderID = 3, ItemName = "Samosa", OrderDate = new DateTime(2024, 6, 12), Quantity = 2 },
                new Order6() { OrderID = 4, ItemName = "Cake", OrderDate = new DateTime(2024, 4, 2), Quantity = 1 },
                new Order6() { OrderID = 5, ItemName = "Juice", OrderDate = new DateTime(2024, 2, 10), Quantity = 5 },
            };

            List<Item6> items = new List<Item6>()
            {
                new Item6() { ItemName = "Biryani", Price = 500 },
                new Item6() { ItemName = "Pizza", Price = 200 },
                new Item6() { ItemName = "Samosa", Price = 100 },
                new Item6() { ItemName = "Cake", Price = 600 },
                new Item6() { ItemName = "Juice", Price = 50 }
            };

            var Tprice = from order in orders
                         join item in items on order.ItemName equals item.ItemName
                         select new
                         {
                             order.OrderID,
                             order.ItemName,
                             order.OrderDate,
                             TotalPrice = order.Quantity * item.Price
                         };

            foreach (var i in Tprice)
            {
                Console.WriteLine($"Order ID: {i.OrderID}, Item Name: {i.ItemName},OrderDate:{i.OrderDate}, Total Price: {i.TotalPrice}");
            }
        }
    }
}
