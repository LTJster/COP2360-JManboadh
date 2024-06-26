using System; // Importing the System namespace
using System.Collections.Generic; // Importing the Collections.Generic namespace

// Definition of the Contractor class
public class Contractor
{
    // Member variables for the Contractor class
    private string contractorName;
    private int contractorNumber;
    private DateTime contractorStartDate;

    // Constructor to initialize Contractor object
    public Contractor(string name, int number, DateTime startDate)
    {
        contractorName = name;
        contractorNumber = number;
        contractorStartDate = startDate;
    }

    // Accessor method to get contractor name
    public string GetContractorName()
    {
        return contractorName;
    }

    // Accessor method to get contractor number
    public int GetContractorNumber()
    {
        return contractorNumber;
    }

    // Accessor method to get contractor start date
    public DateTime GetContractorStartDate()
    {
        return contractorStartDate;
    }

    // Mutator method to set contractor name
    public void SetContractorName(string name)
    {
        contractorName = name;
    }

    // Mutator method to set contractor number
    public void SetContractorNumber(int number)
    {
        contractorNumber = number;
    }

    // Mutator method to set contractor start date
    public void SetContractorStartDate(DateTime startDate)
    {
        contractorStartDate = startDate;
    }
}

// Definition of the Subcontractor class, inheriting from Contractor
public class Subcontractor : Contractor
{
    // Member variables for Subcontractor class
    private int shift;
    private double hourlyPayRate;

    // Constructor to initialize Subcontractor object, inheriting from Contractor
    public Subcontractor(string name, int number, DateTime startDate, int shift, double hourlyPayRate)
        : base(name, number, startDate)
    {
        this.shift = shift;
        this.hourlyPayRate = hourlyPayRate;
    }

    // Accessor method to get shift
    public int GetShift()
    {
        return shift;
    }

    // Accessor method to get hourly pay rate
    public double GetHourlyPayRate()
    {
        return hourlyPayRate;
    }

    // Mutator method to set shift
    public void SetShift(int shift)
    {
        this.shift = shift;
    }

    // Mutator method to set hourly pay rate
    public void SetHourlyPayRate(double hourlyPayRate)
    {
        this.hourlyPayRate = hourlyPayRate;
    }

    // Method to compute pay with shift differential
    public float ComputePay(float hoursWorked)
    {
        float basePay = 0;
        float overtimePay = 0;

        if (hoursWorked <= 40)
        {
            basePay = (float)(hourlyPayRate * hoursWorked);
        }
        else
        {
            float overtimeHours = hoursWorked - 40;
            overtimePay = (float)(overtimeHours * hourlyPayRate * 1.5);
            basePay = (float)(hourlyPayRate * 40); // Base pay for 40 regular hours
        }

        if (shift == 2) // Night shift
        {
            basePay *= 1.03f; // Add 3% shift differential to base pay
        }

        return basePay + overtimePay;
    }
}

// Definition of the Program class containing the Main method
public class Program
{
    // Entry point of the program
    public static void Main()
    {
        // List to store subcontractors
        List<Subcontractor> subcontractors = new List<Subcontractor>();

        while (true)
        {
            // Prompt for subcontractor name
            Console.Write("Enter subcontractor name (or 'exit' to finish): ");
            string name = Console.ReadLine();
            if (name.ToLower() == "exit")
            {
                break; // Exit loop if user types 'exit'
            }

            // Prompt for contractor number
            Console.Write("Enter contractor number: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Invalid input. Enter contractor number: ");
            }

            // Prompt for contractor start date
            Console.Write("Enter contractor start date (yyyy-mm-dd): ");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.Write("Invalid input. Enter contractor start date (yyyy-mm-dd): ");
            }

            // Prompt for shift
            Console.Write("Enter shift (1 for day, 2 for night): ");
            int shift;
            while (!int.TryParse(Console.ReadLine(), out shift) || (shift != 1 && shift != 2))
            {
                Console.Write("Invalid input. Enter shift (1 for day, 2 for night): ");
            }

            // Prompt for hourly pay rate
            Console.Write("Enter hourly pay rate: ");
            double hourlyPayRate;
            while (!double.TryParse(Console.ReadLine(), out hourlyPayRate))
            {
                Console.Write("Invalid input. Enter hourly pay rate: ");
            }

            // Create new subcontractor and add to the list
            Subcontractor subcontractor = new Subcontractor(name, number, startDate, shift, hourlyPayRate);
            subcontractors.Add(subcontractor);

            // Prompt for hours worked
            Console.Write("Enter hours worked: ");
            float hoursWorked;
            while (!float.TryParse(Console.ReadLine(), out hoursWorked))
            {
                Console.Write("Invalid input. Enter hours worked: ");
            }

            // Compute and display pay
            float pay = subcontractor.ComputePay(hoursWorked);
            Console.WriteLine($"Computed pay for {name}: ${pay}\n");
        }

        // Display all subcontractors
        Console.WriteLine("All subcontractors:");
        foreach (Subcontractor sc in subcontractors)
        {
            Console.WriteLine($"Name: {sc.GetContractorName()}, Number: {sc.GetContractorNumber()}, Start Date: {sc.GetContractorStartDate()}, Shift: {sc.GetShift()}, Hourly Pay Rate: {sc.GetHourlyPayRate()}");
        }
    }
}
