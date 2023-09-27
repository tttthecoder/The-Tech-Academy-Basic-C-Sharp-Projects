using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodAssignment
{
    static class staticNumber
    {
        public static void mathMethod(int input)
        {
            int result = input / 2;
            Console.WriteLine("{0} divided by 2 is: {1}", input, result);
        }
    }
}
