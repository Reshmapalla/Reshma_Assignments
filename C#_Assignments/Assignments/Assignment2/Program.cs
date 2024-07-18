using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Assignment2
{

    /* internal class Program
     {
         static void Main()

         {
             double balance = 1000.0;
             double monthlyInterestRate = 0.015;
             double monthlyPayment;
             double totalPayments = 0.0;

             int month = 1;

             Console.Write("Enter the monthly payment: ");
             monthlyPayment = double.Parse(Console.ReadLine());
             while (balance > 0)
             {
                 balance = balance + (balance * monthlyInterestRate);
                 balance = balance - monthlyPayment;
                 if (balance < 0)
                 {
                     balance = 0;
                 }
                 totalPayments += monthlyPayment;
                 Console.WriteLine($"Month:{month} balance:{balance:F2} payment:{totalPayments:F2}");
                 month++;
             }
         }
     }*/
    class Bank
    {
        static void Main()
        {
            double CreditBalance = 10000;
            double interest = 0.015;
            double MonthlyPayment;
            double TotalPayment = 0;
            Console.WriteLine("enter Monthly payment: ");
            MonthlyPayment = double.Parse(Console.ReadLine());
            int Month = 1;
            while (CreditBalance > 0)
            {
                CreditBalance = CreditBalance = CreditBalance * interest;
                CreditBalance = CreditBalance - MonthlyPayment;
                if (CreditBalance < 0)
                { Console.WriteLine("balance=0"); }
                TotalPayment = TotalPayment + MonthlyPayment;
                Month++;


            }
            Month++;
            Console.WriteLine($"Credit Balance: {CreditBalance}  ");



        }
    


           
    }
}

    







  

    
