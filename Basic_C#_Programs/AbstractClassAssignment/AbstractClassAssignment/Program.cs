using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an Emnployee, which morph into the Person class.
            Person employee = new Employee() { firstName = "Tin", lastName = "Tran" };
            //Call the method on the Employee object.
            employee.SayName();
            Console.ReadLine();
        }
    }
}
