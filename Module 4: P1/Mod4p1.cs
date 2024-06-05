// Import the 'System' namespace
using System;

// Create the 'Program' class
class Program
{
    // Initialize the 'Main' method
    static void Main(string[] args)
    {
        // Create a 'while' loop
        while (true)
        {
            try
            {
                // Prompt the user to enter the dividend or 'exit' to exit the loop
                Console.Write("Enter the dividend (or type 'exit' to quit): ");
                string input1 = Console.ReadLine();
                if (input1.ToLower() == "exit") break; // Exit the loop
                int number1 = Convert.ToInt32(input1);

                // Prompt the user to enter the divisor  or 'exit' to exit the loop
                Console.Write("Enter the divisor (or type 'exit' to quit): ");
                string input2 = Console.ReadLine();
                if (input2.ToLower() == "exit") break; // Exit the loop
                int number2 = Convert.ToInt32(input2);

                // Check for division by zero
                if (number2 == 0)
                {
                    throw new DivideByZeroException();
                }

                // Perform the division using 'double'
                double result = (double)number1 / number2;

                // Display the result
                Console.WriteLine($"{input1} divided by {input2} = {result}");
            }
            
            // Exception for non-integer values
            catch (FormatException)
            {
                Console.WriteLine("Error: One or both of the inputs were not in a valid format. Please enter valid integers.");
            }

            // Exception for non 32-bit integers
            catch (OverflowException)
            {
                Console.WriteLine("Error: One or both of the inputs are too large or too small to be processed as integers.");
            }

            // Exception for '0' value divisor
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero is not allowed. Please enter a non-zero divisor.");
            }

            // Exception for all other exception types
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            // Prompt to continue or exit the program
            Console.WriteLine("Press any key to continue or type 'exit' to quit: ");
            if (Console.ReadLine().ToLower() == "exit") break; // Exit the loop
        }
    }
}
