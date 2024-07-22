using System;
using System.Collections.Generic;
using System.IO;

class demo3
{
    static void Main()
    {
        // Define the path to the file
        string filePath = "products.txt";

        // Read all lines from the file
        string[] lines = File.ReadAllLines(filePath);

        // Create a list to store updated product details
        List<string> updatedLines = new List<string>();

        // Process each line
        foreach (string line in lines)
        {
            // Split the line into parts using comma as the delimiter
            string[] parts = line.Split(',');

            if (parts.Length == 3)
            {
                // Extract product details
                string productId = parts[0].Trim();
                string productName = parts[1].Trim();
                decimal productPrice;

                // Parse the price and increment it by 10%
                if (decimal.TryParse(parts[2].Trim(), out productPrice))
                {
                    productPrice *= 1.10m; // Increase price by 10%
                }

                // Create the updated line with the new price
                string updatedLine = $"{productId}, {productName}, {productPrice:F2}";
                updatedLines.Add(updatedLine);
            }
        }

        // Write the updated lines back to the file
        File.WriteAllLines(filePath, updatedLines);

        Console.WriteLine("Product details updated successfully.");
    }
}

