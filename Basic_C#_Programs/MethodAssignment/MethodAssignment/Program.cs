using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Number numObject1 = new Number();
            Console.WriteLine("Enter your first integer number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your second integer number(this is optional, if you want to skip just press Enter key): ");
            try
            {
                int num2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("{0} multiplied by {1} equals: {2}", num1, num2, numObject1.mathMethod(num1, num2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("We will take care of the 2nd integer for you.");
                Console.WriteLine("{0} multiplied by 1 equals: {1}", num1, numObject1.mathMethod(num1));

            }
            Console.ReadLine();
        }
    }
}
