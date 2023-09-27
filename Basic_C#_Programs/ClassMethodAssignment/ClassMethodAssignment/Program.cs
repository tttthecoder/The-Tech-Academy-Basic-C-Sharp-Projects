using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Number numberObject = new Number();
            Console.WriteLine("Enter your number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            numberObject.mathMethod(num1);

            //Calling the 2nd version of the method.
            Console.WriteLine("Enter your last name: ");
            string lastName = Console.ReadLine();
            numberObject.mathMethod(lastName);

            //Calling the static class method.
            staticNumber.mathMethod(1);

            Console.ReadLine();
        }
    }
}
