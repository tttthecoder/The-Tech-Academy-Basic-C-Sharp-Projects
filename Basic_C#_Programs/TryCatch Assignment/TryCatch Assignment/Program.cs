using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatch_Assignment
{
    //Create the LessThanZeroException class that inherit from Exception
    public class LessThanZeroException : Exception
    {
        //LessThanZeroException() constructor inherits from or invokes the Exception() constructor when it is run.
        public LessThanZeroException(string msg) : base(msg) {
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your age: ");
            try
            {
                int age = Convert.ToInt32(Console.ReadLine());
                //Check if the age was less than zero or equal to zero.
                if (age <= 0)
                {

                    //Create an object of type LessThanZeroException with the Message prop is set to the specified string.
                    LessThanZeroException error = new LessThanZeroException("Less than zero age was entered!");
                    //Throw the exception
                    throw error;
                }
                int ageInDays = age * 365;
                TimeSpan timeSpan = new TimeSpan(ageInDays, 0, 0, 0);
                DateTime yearOfBirth = DateTime.Now - timeSpan;
                Console.WriteLine("You was born in " + yearOfBirth.Year.ToString());
            }
            //Catch the specialized exception.
            catch (LessThanZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Catch the generic exception.
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
