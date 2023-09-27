using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMethodAssignment
{
    class Number
    {
        public int mathMethod(int num1)
        {
            return num1 + 1;
        }
        public int mathMethod(decimal num1)
        {
            return Convert.ToInt32(num1 + 1);
        }
        public int mathMethod(string num1)
        {
            return (Convert.ToInt32(num1) * 10);
        }

    }
}
