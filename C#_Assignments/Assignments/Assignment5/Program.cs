using System;

public class Furniture
{
    public string OrderId { get; set; }
    public string OrderDate { get; set; }
    public string FurnitureType { get; set; }
    public int Qty { get; set; }
    public double TotalAmt { get; set; }
    public string PaymentMode { get; set; }

    public virtual void GetData()
    {
        Console.Write("Enter Order ID: ");
        OrderId = Console.ReadLine();
        Console.Write("Enter Order Date: ");
        OrderDate = Console.ReadLine();
        Console.Write("Enter Furniture Type (Chair/Cot): ");
        FurnitureType = Console.ReadLine();
        Console.Write("Enter Quantity: ");
        Qty = int.Parse(Console.ReadLine());
        Console.Write("Enter Total Amount: ");
        TotalAmt = double.Parse(Console.ReadLine());
        Console.Write("Enter Payment Mode (credit/debit card): ");
        PaymentMode = Console.ReadLine();
    }

    public virtual void ShowData()
    {
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine($"Order Date: {OrderDate}");
        Console.WriteLine($"Furniture Type: {FurnitureType}");
        Console.WriteLine($"Quantity: {Qty}");
        Console.WriteLine($"Total Amount: {TotalAmt}");
        Console.WriteLine($"Payment Mode: {PaymentMode}");
    }
}

public class Chair : Furniture
{
    public string ChairType { get; set; }
    public string Purpose { get; set; }
    public string WoodType { get; set; }
    public string SteelType { get; set; }
    public string PlasticColor { get; set; }
    public double Rate { get; set; }

    public override void GetData()
    {
        base.GetData();
        Console.Write("Enter Chair Type (Wood/Steel/Plastic): ");
        ChairType = Console.ReadLine();
        Console.Write("Enter Purpose (Home/Office): ");
        Purpose = Console.ReadLine();
        if (ChairType.ToLower() == "wood")
        {
            Console.Write("Enter Wood Type (Teak Wood/Rose Wood): ");
            WoodType = Console.ReadLine();
        }
        else if (ChairType.ToLower() == "steel")
        {
            Console.Write("Enter Steel Type (Gray Steel/Green Steel/Brown Steel): ");
            SteelType = Console.ReadLine();
        }
        else if (ChairType.ToLower() == "plastic")
        {
            Console.Write("Enter Plastic Color (Green/Red/Blue/White): ");
            PlasticColor = Console.ReadLine();
        }
        Console.Write("Enter Rate: ");
        Rate = double.Parse(Console.ReadLine());
    }

    public override void ShowData()
    {
        base.ShowData();
        Console.WriteLine($"Chair Type: {ChairType}");
        Console.WriteLine($"Purpose: {Purpose}");
        if (ChairType.ToLower() == "wood")
        {
            Console.WriteLine($"Wood Type: {WoodType}");
        }
        else if (ChairType.ToLower() == "steel")
        {
            Console.WriteLine($"Steel Type: {SteelType}");
        }
        else if (ChairType.ToLower() == "plastic")
        {
            Console.WriteLine($"Plastic Color: {PlasticColor}");
        }
        Console.WriteLine($"Rate: {Rate}");
    }
}

public class Cot : Furniture
{
    public string CotType { get; set; }
    public string WoodType { get; set; }
    public string SteelType { get; set; }
    public string Capacity { get; set; }
    public double Rate { get; set; }

    public override void GetData()
    {
        base.GetData();
        Console.Write("Enter Cot Type (Wood/Steel): ");
        CotType = Console.ReadLine();
        if (CotType.ToLower() == "wood")
        {
            Console.Write("Enter Wood Type (Teak Wood/Rose Wood): ");
            WoodType = Console.ReadLine();
        }
        else if (CotType.ToLower() == "steel")
        {
            Console.Write("Enter Steel Type (Gray Steel/Green Steel/Brown Steel): ");
            SteelType = Console.ReadLine();
        }
        Console.Write("Enter Capacity (Single/Double): ");
        Capacity = Console.ReadLine();
        Console.Write("Enter Rate: ");
        Rate = double.Parse(Console.ReadLine());
    }

    public override void ShowData()
    {
        base.ShowData();
        Console.WriteLine($"Cot Type: {CotType}");
        if (CotType.ToLower() == "wood")
        {
            Console.WriteLine($"Wood Type: {WoodType}");
        }
        else if (CotType.ToLower() == "steel")
        {
            Console.WriteLine($"Steel Type: {SteelType}");
        }
        Console.WriteLine($"Capacity: {Capacity}");
        Console.WriteLine($"Rate: {Rate}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter details for a Chair:");
        Chair chair = new Chair();
        chair.GetData();
        chair.ShowData();

        Console.WriteLine("\nEnter details for a Cot:");
        Cot cot = new Cot();
        cot.GetData();
        cot.ShowData();
    }
}