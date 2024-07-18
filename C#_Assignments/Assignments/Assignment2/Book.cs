using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*.For an Online Bookstore create a class to store book details and display the book details with fields 
isbn, bookname, booktitle, bookauthor, quantityofbooks, bookprice.calculate and display the bill amount
[Note: Use Suitable Methods]*/

namespace Assignment2
{
    internal class Book
    {
        public string isbn;
        public string bookname;
        public string title;
        public string author;
        public int QuantityOfbooks;
        public double bookPrice;
        public Book(string isbn,string bookname,string title ,string author,int quantityOfbooks ,double bookPrice)
        {
            this.isbn= isbn;
            this.bookname= bookname;
            this.title= title;
                this.author= author;
                 this.QuantityOfbooks= quantityOfbooks;
            this.bookPrice= bookPrice;

        }

        public void Bill()
        {
            
            bookPrice = bookPrice * QuantityOfbooks;

            Console.WriteLine($"isbn:{isbn}");



        }

    }
}
