// In Module 7, we discussed different Data Types and Data Structures. For this assignment, your group will develop a dictionary.
// Your group will choose the keys and associated values to be stored in the dictionary.
// Tasks to Complete:
// 1. Create a Switch Statement: Implement a switch statement that allows the user to perform the following tasks:
// a. Populate the Dictionary: Add keys and values determined by your group.
// b. Display Dictionary Contents: Show the contents of the dictionary using any of the three enumeration methods covered in Module 7.
// c. Remove a Key: Remove a specified key from the dictionary.
// d. Add a New Key and Value: Insert a new key-value pair into the dictionary.
// e. Add a Value to an Existing Key: Append a new value to an existing key.
// f. Sort the Keys: Sort the keys in the dictionary.
// 2. Submission: Submit a link to your group's work stored in a GitHub repository.
// Make sure your code is well-organized and thoroughly commented to explain each section's functionality.

using System; // Importing the System namespace
using System.Collections.Generic; // Importing the Collections namespace for using collections like Dictionary and List

class Program
{
    // Created a dictionary to store MLB teams and their details
    static Dictionary<string, List<string>> mlbTeams = new Dictionary<string, List<string>>();

    // Created a method to populate the dictionary with MLB teams and their details
    static void PopulateDictionary()
    {
        mlbTeams["Boston Red Sox"] = new List<string> { "Fenway Park", "David Ortiz", "Mookie Betts" };
        mlbTeams["New York Yankees"] = new List<string> { "Yankee Stadium", "Derek Jeter", "Aaron Judge" };
        mlbTeams["Houston Astros"] = new List<string> { "Minute Maid Park", "Jose Altuve", "George Springer" };
    }

    // Created a method to display the contents of the dictionary
    static void DisplayDictionaryContents()
    {
        // Created a collector and foreach loop to iterate through the dictionary keys
        ICollection<string> teamNames = mlbTeams.Keys;

        foreach (var teamName in teamNames)
        {
            Console.WriteLine($"Team: {teamName}"); // Prints the team name (key)
            Console.WriteLine("Details:"); // Prints the string 'Details:'
            
            // Created a foreach loop to iterate through each value of a team (key)
            foreach (var detail in mlbTeams[teamName])
            {
                Console.WriteLine($"- {detail}"); // Prints the team details (values)
            }
            Console.WriteLine(); // Prints a blank line for better readability
        }
    }

    // Created a method to format user input to proper nouns
    static string CapitalizeFormat(string input)
    {
        char[] charArray = input.ToLower().ToCharArray();
        bool isNewWord = true;

        for (int i = 0; i < charArray.Length; i++)
        {
            if (isNewWord && char.IsLetter(charArray[i]))
            {
                charArray[i] = char.ToUpper(charArray[i]);
                isNewWord = false;
            }
            else if (charArray[i] == ' ')
            {
                isNewWord = true;
            }
        }
        return new string(charArray);
    }

    // Method to insert a new MLB team and its details
    static void AddNewTeam()
    {
        // Prompts the user to enter a key
        Console.WriteLine("What is the name of the Team?");
        string teamName = CapitalizeFormat(Console.ReadLine());

        // Checks to see if the team name is already in the dictionary
        if (mlbTeams.ContainsKey(teamName))
        {
            Console.WriteLine($"{teamName} already exists in the dictionary.");
            return;
        }

        // Prompts the user to enter key-vaules
        Console.WriteLine("What is the name of the Team's stadium?");
        string teamStadium = CapitalizeFormat(Console.ReadLine());
        Console.WriteLine("Enter the name of two players on the Team (one name per line):");
        string player1 = CapitalizeFormat(Console.ReadLine());
        string player2 = CapitalizeFormat(Console.ReadLine());

        mlbTeams[teamName] = new List<string> {teamStadium, player1, player2};
    }

    // Method to remove a key from the dictionary
    static void RemoveTeam()
    {
        // Prompts the user to remove a key
        Console.WriteLine("Enter the name of the Team to remove:");
        string teamName = CapitalizeFormat(Console.ReadLine());

        if (mlbTeams.Remove(teamName))
        {
            Console.WriteLine($"{teamName} removed from the dictionary.");
        }
        else
        {
            Console.WriteLine($"{teamName} not found in the dictionary.");
        }
    }

    // Method to add a value to an existing key
    static void AddValueToExistingTeam()
    {
        // Prompts the user to enter a key
        Console.WriteLine("Enter the name of the Team to modify:");
        string teamName = CapitalizeFormat(Console.ReadLine());

        if (mlbTeams.ContainsKey(teamName))
        {
            Console.WriteLine("Enter the name of the player to add:");
            string value = CapitalizeFormat(Console.ReadLine());
            mlbTeams[teamName].Add(value);
            Console.WriteLine($"{value} added to {teamName}.");
        }
        else
        {
            Console.WriteLine($"{teamName} not found in the dictionary.");
        }
    }

    // Method to sort and display the keys of the dictionary
    static void SortKeys()
    {
        var sortedKeys = new List<string>(mlbTeams.Keys);
        sortedKeys.Sort();
        Console.WriteLine("Sorted Teams:");
        foreach (var key in sortedKeys)
        {
            Console.WriteLine($"{key}: {string.Join(", ", mlbTeams[key])}");
        }
    }
    // The start of the program
    static void Main(string[] args)
    {
        PopulateDictionary();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nChoose an option:"); // '\n' Adds a newline before the prompt
            Console.WriteLine("1. Display Dictionary Contents");
            Console.WriteLine("2. Remove a Team");
            Console.WriteLine("3. Add a new Team with details");
            Console.WriteLine("4. Modify an existing Team");
            Console.WriteLine("5. Sort the Teams");
            Console.WriteLine("6. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    DisplayDictionaryContents();
                    break;
                case "2":
                    RemoveTeam();
                    break;
                case "3":
                    AddNewTeam();
                    break;
                case "4":
                    AddValueToExistingTeam();
                    break;
                case "5":
                    SortKeys();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
