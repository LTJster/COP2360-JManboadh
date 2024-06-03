using System; // Import 'System' namespace

// Create the 'Person' class
public class Person
{
    // Create private fields within the 'Person' class
    private string firstName;
    private string lastName;
    private int age;

    // Create an enum for Demographic Category
    public enum DemographicCategory
    {
        Child,
        Adult,
        Elderly
    }

    // Create a constructor for the 'Person' object
    public Person(string firstName, string lastName, int age)
    {
        // Initialize the 'Person' object with names and ages
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    // Public properties to get and set the fields
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    // Create a method to determine the demographic category
    public DemographicCategory GetDemographic()
    {
        if (age < 18)
        {
            return DemographicCategory.Child;
        }
        else if (age < 65)
        {
            return DemographicCategory.Adult;
        }
        else
        {
            return DemographicCategory.Elderly;
        }
    }

    // Create a method to display the output
    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {firstName} {lastName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Demographic Category: {GetDemographic()}");
        Console.WriteLine(); // Adds a blank line between each person
    }
}

// Create the 'Display' class
class Display
{
    // Start of the program
    static void Main(string[] args)
    {
        // Create individual instances of the Person class
        Person person1 = new Person("Charles", "Dodgson", 30);
        Person person2 = new Person("Alice", "Liddell", 8);
        Person person3 = new Person("Lewis", "Carroll", 73);

        // Display details for each person
        person1.DisplayDetails();
        person2.DisplayDetails();
        person3.DisplayDetails();
    }
}
