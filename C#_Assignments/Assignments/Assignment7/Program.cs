using System.Xml.Linq;

namespace Assignment7
{/*
    5. Create a class with name student and store all the student details in an List and Display the
Details.
Perform the following operations with respect to Student
A. AddStudent
B. GetAllStudents
C. GetStudentById
D. RemoveStudent
E. UpdateStudent
Note: declare the above functionalities in IStudentRepository and implement in StudentRepository
Class*/
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"ID: {Id} Name: {Name} Email: {Email}";
        }

    }
    class List_Item
    {
        static void Main()
        {
            Student student = new Student();
            student.Id = 1;
            student.Name = "John";
            student.Email = "John12@gmail.com";
            List<Student> list = new List<Student>()
            {
                new Student() {Id=1,Name="joseph",Email="Joseph34@gmail.com"},
                new Student() {Id=2,Name="Ron",Email="Ron56@gmail.com"},
                new Student() {Id=3,Name="lilly",Email="lilly76@gmail.com"},
                new Student() {Id=4,Name="hermoine",Email="hermoine768@gmail.com"},
                new Student() {Id=5,Name="james",Email="james7@gmail.com"}

            };

            list.Add(new Student { Id = 2, Name = "Kalix", Email = "Kalix2@gmail.com" });
            list.Add(student);
            Student s1 = list[3];
            Console.WriteLine(s1.ToString());
            list.Remove(s1);
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            list.Clear();


        }

    }

}