using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Accounts
    {
        public long Account_no;
        public string Customer_Name;
        public string Account_Type;

        public double balance = 0;
        void accept(string Customer_Name, string Account_Type)
        {
            Console.WriteLine("Enter  Name and Acc Type");
            this.Customer_Name = Customer_Name;
            this.Account_Type = Account_Type;
        }
        void display()
        {
            Random r = new Random();
            Console.WriteLine($"AccNo: {r.Next(10000, 999999)}\n Naame: {this.Customer_Name}" +
                $"\nAccount_type:{this.Account_Type}\n");

        }
        void Deposit(long amount)
        {
            this.balance = this.balance + amount;
            Console.WriteLine($"Your balance is {this.balance}");


        }
        void withdraw(long amount)
        {
            if (this.balance <= 0)
            {
                Console.WriteLine("Your balance is low");
                Console.WriteLine($"Your balance is {this.balance}");


            }
            else
            {

                this.balance = this.balance - amount;
                Console.WriteLine($"Your balance is {this.balance}");

            }
        }

        static void Main()
        {
            Console.WriteLine("Select the Transcation\n1.Deposit\n2.Withdraw");
            int option = int.Parse(Console.ReadLine());
            Accounts accounts = new Accounts();
            if (option == 1)
            {
                Console.WriteLine("Enter the amount to Diposit");
                long amount = long.Parse(Console.ReadLine());

                accounts.Deposit(amount);
            }
            else if (option == 2)
            {
                Console.WriteLine("Enter the amount to withdraw");
                long amount = long.Parse(Console.ReadLine());
                accounts.withdraw(amount);
            }
            else
                Console.WriteLine("Enter correct option");
            accounts.display();

        }


    }
}
