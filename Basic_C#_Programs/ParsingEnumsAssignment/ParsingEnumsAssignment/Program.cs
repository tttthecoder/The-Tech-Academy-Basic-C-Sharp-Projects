using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingEnumsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    //Promt for user input.
                    Console.WriteLine("Enter the current day of the week: ");
                    string inputDay = Console.ReadLine();
                    //Parse the string value to a value of enum type.
                    DaysofTheWeek day = (DaysofTheWeek)Enum.Parse(typeof(DaysofTheWeek), inputDay);
                    Console.WriteLine("Have a nice " + day + "!");
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();

            }
        }
    }
    //Creates the enum type class.
    public enum DaysofTheWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
}
