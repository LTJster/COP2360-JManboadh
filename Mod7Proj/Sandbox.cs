using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, List<string>> mlbTeams = new Dictionary<string, List<string>>();

    static void PopulateDictionary()
    {
        mlbTeams["Boston Red Sox"] = new List<string> { "Fenway Park", "David Ortiz", "Mookie Betts" };
        mlbTeams["New York Yankees"] = new List<string> { "Yankee Stadium", "Derek Jeter", "Aaron Judge" };
        mlbTeams["Houston Astros"] = new List<string> { "Minute Maid Park", "Jose Altuve", "George Springer" };
    }
    
    static void Main(string[] args)
    {
        PopulateDictionary();
        Console.WriteLine("Dictionary populated.");
    }
}
