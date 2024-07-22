using System;
using System.Collections.Generic;
using System.Linq;

public class Participant
{
    public string Name { get; set; }
    public string Country { get; set; }
}

class Program
{
    static void Main()
    {
        List<Participant> participants = new List<Participant>
        {
            new Participant { Name = "Player1", Country = "CountryA" },
            new Participant { Name = "Player2", Country = "CountryB" },
            new Participant { Name = "Player3", Country = "CountryA" },
            new Participant { Name = "Player4", Country = "CountryB" },
            new Participant { Name = "Player5", Country = "CountryC" },
            new Participant { Name = "Player6", Country = "CountryD" }
            // Add more participants as needed
        };






        // Split participants into two equal halves
        var halfCount = participants.Count / 2;
        var firstHalf = participants.Take(halfCount);
        var secondHalf = participants.Skip(halfCount);

        // Generate all possible matches
        var matches = from p1 in firstHalf
                      from p2 in secondHalf
                      where p1.Country != p2.Country  // Ensure players are from different countries
                      select new { Player1 = p1, Player2 = p2 };

        // Display all possible matches
        foreach (var match in matches)
        {
            Console.WriteLine($"{match.Player1.Name} ({match.Player1.Country}) vs {match.Player2.Name} ({match.Player2.Country})");
        }
    }
}