using System;
using System.Globalization;

namespace MathAndComparisonOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            //We start the application.
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
            //Accept user input for the weight and check if its greater than 50
            Console.WriteLine("Please enter the package weight:");
            decimal packWeight = Convert.ToDecimal(Console.ReadLine());
            if (packWeight > 50)
            {
                //If the weight is greater than 50, we reject the shipping order and close the application.
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                Console.WriteLine("Press Enter key to exit.");
                Console.ReadLine();
            }
            else
            {
                //Else, we ask the user for more info to calculate the quote.
                Console.WriteLine("Please enter the package width:");
                decimal packWidth = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Please enter the package height:");
                decimal packHeight = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Please enter the package length:");
                decimal packLength = Convert.ToDecimal(Console.ReadLine());
                decimal dimensionsTotal = packWidth + packHeight + packLength;
                if (dimensionsTotal > 50)
                {
                    //If the total dimensions is greater than 50, we reject the shipping order and close the application.
                    Console.WriteLine("Package too big to be shipped via Package Express. Have a good day.");
                    Console.WriteLine("Press Enter key to exit.");
                    Console.ReadLine();
                }
                else
                {
                    //Else, we calculate the quote.
                    decimal quote = (packWidth * packHeight * packLength) * packWeight / 100;
                    //By using the "C" format specifier, we can change our quote decimal to a string representing a dollar amount.
                    Console.WriteLine("Our estimated total for shipping this package is: " + quote.ToString("C", CultureInfo.CurrentCulture));
                    Console.WriteLine("Press Enter key to exit.");
                    Console.ReadLine();

                }
            }

        }
    }
}
