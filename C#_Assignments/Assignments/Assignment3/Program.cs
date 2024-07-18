namespace Assignment3
{
     class Person
    {
        public string FirstName;
        public string LastName;
        public string EmailAddress;
       // public string DateOfBirth;
        public DateTime DateOfBirth;
       public  Person (string firstname,string lastname,string email,DateTime dob)
        {
            FirstName = firstname;
            LastName = lastname;
            EmailAddress = email;
            DateOfBirth = dob;
        }
        public void show()
        {
            Console.WriteLine($"Firstname: {FirstName} LastName: {LastName} email: {EmailAddress} DateofBirth;{DateOfBirth}");
        }
       public  Person (string firstname,string lastname,string email)
        {
            FirstName = firstname;
            LastName = lastname;
            EmailAddress = email;

        }
        public void show1()
        {
            Console.WriteLine($"FirstName:{FirstName} LastName:{LastName} email:{EmailAddress}");
        }

       public  Person (string firstname,string lastname,DateTime dob)

        {
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth= dob;   

        }
        public void show2()
        {
            Console.WriteLine($"Firstname;{FirstName} LastName:{LastName} DateOfBirth:{DateOfBirth}");

        }
    }
    class Program
    {
        static void Main()
        {
            Person obj = new Person("reshma", "palla", "reshmapalla2@gmail.com", new DateTime(2001, 04, 11));
            Person obj1 = new Person("sushma", "palla", "sushmapalla2@gmail.com");
            Person obj2 = new Person("gayathri", "landa", new DateTime(2001, 03, 11));
            obj.show();
            obj1.show1();
            obj2.show2();
        }




    }
}