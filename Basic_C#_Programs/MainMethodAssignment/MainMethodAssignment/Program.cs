using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMethodAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------method 1---------------------------");
            Number numObject = new Number();
            int num1 = numObject.mathMethod(9);
            Console.WriteLine("The result of calling the mathMethod() method is: "+ num1);

            Console.WriteLine("---------------------------method 2---------------------------");
            Number numObject2 = new Number();
            int num2 = numObject2.mathMethod(91.22m);
            Console.WriteLine("The result of calling the decimal version of the mathMethod() method is: " + num2);

            Console.WriteLine("---------------------------method 3---------------------------");
            try
            {
                Number numObject3 = new Number();
                int num3 = numObject3.mathMethod("91m");
                Console.WriteLine("The result of calling the decimal version of the mathMethod() method is: " + num3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("The operation done by the 3rd version of the method failed.");
            }
            Console.ReadLine();
        }
    }
}
