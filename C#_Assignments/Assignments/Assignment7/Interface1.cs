using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment7;

namespace Assignment5
{
    /* Create a class with name student and store all the student details in an List  and Display the 
Details. 
Perform the following operations with respect to Student 
A. AddStudent 
B. GetAllStudents 
C. GetStudentById 
D. RemoveStudent 
E. UpdateStudent 
Note: declare the above functionalities in IStudentRepository and implement in StudentRepository class*/
    interface IRepository
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        void AddStudent(Student student);
        void RemoveStudent(int studnetId);
        void UpdateStudent(Student product);

    }
    class StudentRepository : IRepository
    {
        List<Student> students = new List<Student>(); //datasource
        public void AddStudent(Student student)
        {

            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {

            return students;
        }

        public Student GetStudentById(int studentId)
        {
            foreach (Student item in students)
            {
                if (item.Id == studentId) return item;

            }
            return null;
        }

        public void RemoveStudent(int studentId)
        {
            Student student = null;
            foreach (Student item in students)
            {
                if (item.Id == studentId)
                {
                    student = item;
                    break;
                }

            }
            if (student != null)
                students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == student.Id)
                {
                    students[i].Email = student.Email; //update the email
                }
            }
        }
    }
    internal class Demo2
    {
        static void Main()
        {
            StudentRepository repository = new StudentRepository();
            try
            {
                do
                {
                    Console.WriteLine("1.Add\n2.GetById\n3.GetAll\n4.Update\n5.Delete\n6.Exit");
                    Console.WriteLine("Select Option");
                    int op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1: //Add Student
                            {
                                Student student = new Student();
                                student.Id = new Random().Next();
                                Console.WriteLine("Enter Name");
                                student.Name = Console.ReadLine();
                                Console.WriteLine("Enter Email");
                                student.Email = Console.ReadLine();
                                repository.AddStudent(student);
                            }
                            break;
                        case 2: //Search Student
                            {
                                Console.WriteLine("Enter Student Id");
                                int id = int.Parse(Console.ReadLine());
                                Student student = repository.GetStudentById(id);
                                if (student != null)
                                {
                                    Console.WriteLine(student.ToString());
                                }
                                else
                                    Console.WriteLine("Invalid Id");
                            }
                            break;
                        case 3: //Get All Students
                            {
                                List<Student> students = repository.GetAllStudents();
                                if (students.Count > 0)
                                {
                                    foreach (var item in students)
                                    {
                                        Console.WriteLine(item);
                                    }
                                }
                                else
                                    Console.WriteLine("List is Empty");
                            }
                            break;
                        case 5: //delete Student
                            {
                                Console.WriteLine("Enter Student Id");
                                int id = int.Parse(Console.ReadLine());
                                repository.RemoveStudent(id);
                            }
                            break;
                        case 4: //update student
                            {
                                Student student = new Student();
                                student.Id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Email");
                                student.Email = Console.ReadLine();
                                repository.UpdateStudent(student);
                            }
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
