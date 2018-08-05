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
            Console.Write("How many numbers of the Fibonacci series would you like to print?: ");

            double n = Double.Parse(Console.ReadLine());

            Console.Clear();

            Fibonacci(n, 0);
        }

        public static void Fibonacci(double numbers, double startWith)
        {
            double firstNumber = 0,
                secondNumber = 1,
                nextNumber;

            Console.WriteLine("Here are the requested numbers:\n");

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
