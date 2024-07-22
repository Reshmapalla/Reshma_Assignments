using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignments
{

    public class Order
    {
        public int OrderID { get; set; }

        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }
    }
    internal class linq3
    {

        static void Main(string[] args)
        {

            List<Order> order1 = new List<Order>()
            {
                new Order() { OrderID = 1,ItemName="biryani",OrderDate =new DateTime(2024,3,22),Quantity =3 },
                new Order() { OrderID = 2,ItemName="pizza",OrderDate =new DateTime(2024,1,20),Quantity =7 },
                new Order() { OrderID = 3,ItemName="samosa",OrderDate =new DateTime(2024,6,12),Quantity =2},
                new Order() { OrderID = 4,ItemName="cake",OrderDate =new DateTime(2024,4,2),Quantity =1},
                new Order() { OrderID = 5,ItemName="juice",OrderDate =new DateTime(2024,2,10),Quantity =5 },
            };

            var result = from i in order1
                         orderby i.OrderDate descending, i.Quantity descending
                         select i;


            foreach (var item in result)
            {
                Console.WriteLine($"OrderID:{item.OrderID} ,ItemName:{item.ItemName},OrderDate: {item.OrderDate},Quantity: {item.Quantity}");

            }
        }

    }

}