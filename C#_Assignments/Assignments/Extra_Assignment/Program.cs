using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System;
/* You owe the credit card company an amount of M.The company charges you an interest of 1.5%
per month on the unpaid balance. You have decided close the card and pay off the debt by making a
monthly payment of N rupee a month.
Write a program that asks for the monthly payment, the program writes out the balance and total
payments so far for every succeeding month until the balance is zero or less.
Sample Input :
Enter the monthly payment: 100
Sample Output:
Month: 1 balance: 915.0 total payments: 100.0
Month: 2 balance: 828.725 total payments: 200.0
Month: 3 balance: 741.155875 total payments: 300.0*/
namespace Extra_Assignment
{

    internal class Program
    {
      
        static void Main(string[] args)
        {
            double Balance = 1000;
            double interest = 0.015;
            double TotalPayments = 0;
            
            Console.WriteLine("enter MonthlyPayment: ");
            double MonthlyPayment=double.Parse(Console.ReadLine());
            int month = 1;
            while (Balance > 0)
            {
                Balance = Balance+Balance * interest;
                Balance = Balance - MonthlyPayment;
                TotalPayments += MonthlyPayment;
                if (Balance > 0)
                {

                    Console.WriteLine($"Month:{month}  Balance:{Balance} TotalPayments: {TotalPayments}");
                }
                month++;
            }
           
        }
    }
}