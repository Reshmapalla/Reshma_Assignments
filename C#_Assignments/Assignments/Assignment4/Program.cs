using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    /*For an Online Bookstore create a class to store book details and display the book details with fields isbn, bookname, booktitle, bookauthor, quantityofbooks,bookprice.calculate and display the bill amount [Note: Use Properties]

Note: read multiple book details from the user and calculate the total amount.*/
    class BookDetails
    {
        private string isbn, bookname, booktitle, bookauthor, quantityofbooks;
        private double bookprice;
        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string BookName
        {
            get { return bookname; }
            set { bookname = value; }
        }
        public string BookTitle
        {
            get { return booktitle; }
            set { booktitle = value; }
        }
        public string BookAuthor
        {
            get { return bookauthor; }
            set { bookauthor = value; }
        }
        public double BookPrice
        {
            get { return bookprice; }
            set { bookprice = value; }
        }
        public void Display()
        {
            double bill = 0;
            Console.WriteLine("Enter number of Books: ");
            int books = int.Parse(Console.ReadLine());
            bill = books * BookPrice;
            Console.WriteLine("Total bill:" + bill);
            Console.WriteLine($"isbn={ISBN},bookname={BookName},BookTitle={BookTitle},BookAuthor={BookAuthor},BookPrice={bookprice}");
        }

    }
    internal class Problem4
    {
        static void Main()
        {
            BookDetails obj = new BookDetails();
            obj.ISBN = "abc";
            obj.BookName = "Harry Potter";
            obj.BookTitle = "Hogwarts";
            obj.BookAuthor = "Chandini";
            obj.BookPrice = 1000;

            obj.Display();
            /*BookDetails[] obj1= new BookDetails[5];
            for(int i = 0;i < obj1.Length; i++)
            {
                Console.Write($"BookDetails[{i}]");
                obj1[i] = Console.ReadLine();
            }

           */
            BookDetails obj1 = new BookDetails();
            obj1.ISBN = "abc";
            obj1.BookName = "Harry Potter";
            obj1.BookTitle = "Hogwarts";
            obj1.BookAuthor = "Chandini";
            obj1.BookPrice = 2000;

            obj1.Display();

        }
    }
}