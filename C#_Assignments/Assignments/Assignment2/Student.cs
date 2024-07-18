using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Student
    {
        int rollno;
        string name;
        string Class;
        int sem;
        string branch;
        int[] marks;
        Student(int rollno, string name, string Class, int sem, string branch, int[] marks)
        {
            this.rollno = rollno;
            this.name = name;
            this.Class = Class;
            this.sem = sem;
            this.branch = branch;
            this.marks = marks;
        }
        void displayresult()
        {
            Console.WriteLine($"Rollno: {rollno}\nName: {name}\nClass: {Class}\nsem: {sem}\n" +
                $"branch: {branch}\n");
            Console.WriteLine("marks");

            foreach (int i in marks)
            {
                Console.WriteLine(i);
            }
            int total = 0;
            bool pass = true;
            foreach (int i in marks)
            {
                if (i < 35)
                    pass = false;
                total += i;
            }
            double avg = Convert.ToDouble(total / 5);
            Console.WriteLine("Average marks:" + avg);
            if (pass == true && avg < 50)
                pass = false;
            if (pass == false)
                Console.WriteLine("Result : Failed");
            else
                Console.WriteLine("Result : pass");
        }
        static void Main()
        {
            Student student = new Student(23, "Sasya", "MS3", 6, "CSE", new int[5] { 40, 76, 37, 36, 35 });
            student.displayresult();
        }

    }
}
