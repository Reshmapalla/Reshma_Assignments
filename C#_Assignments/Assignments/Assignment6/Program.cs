using System;

public interface IGovtRules
{
    double EmployeePF(double basicSalary);
    string LeaveDetails();
    double GratuityAmount(float serviceCompleted, double basicSalary);
}

public class TCS : IGovtRules
{
    // Data members
    public int EmpId { get; }
    public string Name { get; }
    public string Dept { get; }
    public string Desg { get; }
    public double BasicSalary { get; }

    // Constructor
    public TCS(int empId, string name, string dept, string desg, double basicSalary)
    {
        EmpId = empId;
        Name = name;
        Dept = dept;
        Desg = desg;
        BasicSalary = basicSalary;
    }

    // Implementing the interface methods
    public double EmployeePF(double basicSalary)
    {
        double employeePF = basicSalary * 0.12;
        double employerPF = basicSalary * 0.0833;
        double pensionFund = basicSalary * 0.0367;
        return employeePF + employerPF + pensionFund;
    }

    public string LeaveDetails()
    {
        return "1 day of Casual Leave per month\n" +
               "12 days of Sick Leave per year\n" +
               "10 days of Privilege Leave per year";
    }

    public double GratuityAmount(float serviceCompleted, double basicSalary)
    {
        if (serviceCompleted > 20)
            return 3 * basicSalary;
        if (serviceCompleted > 10)
            return 2 * basicSalary;
        if (serviceCompleted > 5)
            return basicSalary;
        return 0;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Employee ID: {EmpId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Department: {Dept}");
        Console.WriteLine($"Designation: {Desg}");
        Console.WriteLine($"Basic Salary: {BasicSalary}");
        Console.WriteLine($"PF Amount: {EmployeePF(BasicSalary)}");
        Console.WriteLine($"Leave Details: {LeaveDetails()}");
        Console.WriteLine($"Gratuity Amount: {GratuityAmount(6, BasicSalary)}"); // Example for service completed
    }
}

public class Accenture : IGovtRules
{
    // Data members
    public int EmpId { get; }
    public string Name { get; }
    public string Dept { get; }
    public string Desg { get; }
    public double BasicSalary { get; }

    // Constructor
    public Accenture(int empId, string name, string dept, string desg, double basicSalary)
    {
        EmpId = empId;
        Name = name;
        Dept = dept;
        Desg = desg;
        BasicSalary = basicSalary;
    }

    // Implementing the interface methods
    public double EmployeePF(double basicSalary)
    {
        double employeePF = basicSalary * 0.12;
        double employerPF = basicSalary * 0.12;
        return employeePF + employerPF;
    }

    public string LeaveDetails()
    {
        return "2 days of Casual Leave per month\n" +
               "5 days of Sick Leave per year\n" +
               "5 days of Privilege Leave per year";
    }

    public double GratuityAmount(float serviceCompleted, double basicSalary)
    {
        // Gratuity amount is not applicable
        return 0;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Employee ID: {EmpId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Department: {Dept}");
        Console.WriteLine($"Designation: {Desg}");
        Console.WriteLine($"Basic Salary: {BasicSalary}");
        Console.WriteLine($"PF Amount: {EmployeePF(BasicSalary)}");
        Console.WriteLine($"Leave Details: {LeaveDetails()}");
        Console.WriteLine($"Gratuity Amount: {GratuityAmount(6, BasicSalary)}"); // Example for service completed
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create TCS employee
        TCS tcsEmployee = new TCS(101, "John Doe", "IT", "Developer", 50000);
        Console.WriteLine("TCS Employee Details:");
        tcsEmployee.DisplayDetails();

        Console.WriteLine();

        // Create Accenture employee
        Accenture accentureEmployee = new Accenture(102, "Jane Smith", "HR", "Manager", 60000);
        Console.WriteLine("Accenture Employee Details:");
        accentureEmployee.DisplayDetails();
    }
}