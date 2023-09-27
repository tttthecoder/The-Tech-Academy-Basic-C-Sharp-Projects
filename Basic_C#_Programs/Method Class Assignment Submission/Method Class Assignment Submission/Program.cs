using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Class_Assignment_Submission
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate the object
            NumberOperation object1 = new NumberOperation();
            //Call the Operation() method inside the object.
            object1.Operation(12, 23);
            //Call the Operation() method inside the object, this time with parameter names.
            object1.Operation(num1: 12, num2: 22223);
            Console.ReadLine();
        }
    }
}
