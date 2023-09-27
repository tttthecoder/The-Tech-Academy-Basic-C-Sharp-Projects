using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Class_Assignment_Submission
{
    class NumberOperation
    {
        //Create a class, this class will have the method named Operation() and this method will return
        //nothing and be a public method that can be accessed anywhere in the program.
        public void Operation(int num1, int num2)
        {
            //Do the operation on the 1st number.
            int result = num1 ^ 6;
            //Display the second number onto the screen.
            Console.WriteLine("You passed in {0} as the second input integer.", num2);
        }
    }
}
