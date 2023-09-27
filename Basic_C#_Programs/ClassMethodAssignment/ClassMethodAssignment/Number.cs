using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodAssignment
{
    class Number
    {
        public void mathMethod(int input)
        {
            int result = input / 2;
            Console.WriteLine("{0} divided by 2 is: {1}",input, result);
        }
        public void mathMethod(string lastName)
        {
            Console.WriteLine("{0} {1} might be a good name for your child.", "Josh", lastName);
        }
    }
}
