using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /*Create a class called Student with the following details:

    RollNo

    StudName

    MarksInEng

    MarksInMaths

    MarksInScience

    Read all the student details using constructor

    Display the total marks and Percentage of the student.
    */
    class Student1
    {
        int RollNo;
        string StudName;
        int MarksInEng;
        int MarksInMaths;
        int MarksInScience;
        public void StudentDetails(int RollNo, string StudName, int MarksInEng, int MarksInMaths, int MarksInScience)
        {
            this.RollNo = RollNo;
            this.StudName = StudName;
            this.MarksInEng = MarksInEng;
            this.MarksInMaths = MarksInMaths;
            this.MarksInScience = MarksInScience;
            int total = MarksInEng + MarksInMaths + MarksInScience;
            double avg = total / 3;
            double percentage = (avg / 100) * 100;


        }
        void display()
        {
            Console.WriteLine(this.RollNo);
            Console.WriteLine(this.StudName);
            int total = this.MarksInScience + this.MarksInEng + this.MarksInMaths;
            Console.WriteLine("Total marks " + total);
            double per = (total * 100) / 300;
            Console.WriteLine($"Percentage of {this.StudName} is {per}%");


        }
        static void Main()
        {
            Student1st stu = new Student1();
            stu.StudentDetails(12, "chandini", 77, 58, 97);
            stu.display();
        }
    }
}