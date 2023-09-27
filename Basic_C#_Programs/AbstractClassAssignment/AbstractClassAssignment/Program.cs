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
            //Create an Emnployee, which morph into the IQuittable interface.
            IQuittable employee = new Employee() { firstName = "Tin", lastName = "Tran" };
            //Call the Quit() method on the Employee object.
            employee.Quit();

            Console.ReadLine();
        }
    }
}
