using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Staff
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Student
{
    private static int nextId = 1;

    public int Id { get; private set; }
    public string Name { get; set; }
    public DateTime DOB { get; set; }
    public string Gender { get; set; }
    public string Class { get; set; }
    public string Section { get; set; }
    public Staff Staff { get; set; }

    public Student()
    {
        Id = nextId++;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, DOB: {DOB.ToShortDateString()}, Gender: {Gender}, Class: {Class}, Section: {Section}, Staff: {Staff.Name}";
    }
}

class Program
{
    static List<Staff> staffList = new List<Staff>();
    static List<Student> studentList = new List<Student>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Staff");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Display Students by Staff");
            Console.WriteLine("4. Display Students by Class");
            Console.WriteLine("5. Save Students to File");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine());

            try
            {
                switch (option)
                {
                    case 1:
                        AddStaff();
                        break;
                    case 2:
                        AddStudent();
                        break;
                    case 3:
                        DisplayStudentsByStaff();
                        break;
                    case 4:
                        DisplayStudentsByClass();
                        break;
                    case 5:
                        SaveStudentsToFile();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void AddStaff()
    {
        Console.Write("Enter Staff ID: ");
        int id = int.Parse(Console.ReadLine());
        if (staffList.Any(s => s.Id == id))
        {
            throw new Exception("Staff ID already exists");
        }

        Console.Write("Enter Staff Name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Staff Name cannot be null");
        }

        staffList.Add(new Staff { Id = id, Name = name });
        Console.WriteLine("Staff added successfully.");
    }

    static void AddStudent()
    {
        Student student = new Student();

        Console.Write("Enter Student Name: ");
        student.Name = Console.ReadLine();
        Console.Write("Enter DOB (yyyy-mm-dd): ");
        student.DOB = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter Gender: ");
        student.Gender = Console.ReadLine();
        Console.Write("Enter Class: ");
        student.Class = Console.ReadLine();
        Console.Write("Enter Section: ");
        student.Section = Console.ReadLine();

        Console.Write("Enter Staff Name to map the student: ");
        string staffName = Console.ReadLine();
        Staff staff = staffList.FirstOrDefault(s => s.Name.Equals(staffName, StringComparison.OrdinalIgnoreCase));
        if (staff == null)
        {
            throw new Exception("Invalid Staff Name");
        }

        student.Staff = staff;
        studentList.Add(student);
        Console.WriteLine("Student added successfully.");
    }

    static void DisplayStudentsByStaff()
    {
        Console.Write("Enter Staff Name: ");
        string staffName = Console.ReadLine();
        var students = studentList.Where(s => s.Staff.Name.Equals(staffName, StringComparison.OrdinalIgnoreCase)).ToList();
        if (students.Any())
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine("No students found for the given staff.");
        }
    }

    static void DisplayStudentsByClass()
    {
        Console.Write("Enter Class: ");
        string className = Console.ReadLine();
        var students = studentList.Where(s => s.Class.Equals(className, StringComparison.OrdinalIgnoreCase)).ToList();
        if (students.Any())
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine("No students found for the given class.");
        }
    }

    static void SaveStudentsToFile()
    {
        using (StreamWriter sw = new StreamWriter("D:\\sasya.txt"))
        {
            foreach (var student in studentList)
            {
                sw.WriteLine(student);
                sw.WriteLine();
            }
        }
        Console.WriteLine("Students saved to file successfully.");
    }
}
