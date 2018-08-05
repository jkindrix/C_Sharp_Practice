using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            // User instruction
            Console.WriteLine("How many numbers of the Fibonacci series would you like to print?\n");

            // Parse input as a double
            double n = Double.Parse(Console.ReadLine());

            // Clear the console display
            Console.Clear();

            // Print 'n' numbers of the Fibonacci series
            // (Change to the second argument to 1 to start the series at the number 1 instead of 0)
            Fibonacci(n, 0);
        }

        // This Fibonacci() method will write out 'n' numbers of the Fibonacci series to the console using an iterative method
        public static void Fibonacci(double numbers, double startWith)
        {
            double firstNumber = 0, // First number in the series
                secondNumber = 1, // Second number
                nextNumber; // A placeholder for the result of the previous two numbers

            Console.WriteLine("Here are the requested numbers:\n");

            // Input validation for the second parameter
            // (Only allow the numbers 0 or 1)
            try
            {
                switch (startWith)
                {
                    case 0:
                        Console.WriteLine(0);
                        break;
                    case 1:
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.Clear();
                Console.WriteLine("Second argument can only be 0 or 1\n\nPlease try again...");
                return;
            }

            for (double i = 1; i <= numbers; i++)
            {
                Console.WriteLine(secondNumber);

                nextNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
        }
    }
}
