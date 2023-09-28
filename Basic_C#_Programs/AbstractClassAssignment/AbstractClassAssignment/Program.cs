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
            //IQuittable employee = new Employee() { firstName = "Tin", lastName = "Tran" };
            //Call the Quit() method on the Employee object.
            //employee.Quit();
            //Create the 3 employees and giving them different Ids.
            Employee emp1 = new Employee() { firstName = "Peter", lastName = "Pham", Id= 123 };
            Employee emp2 = new Employee() { firstName = "Hao", lastName = "Vu", Id = 124};
            Employee emp3 = new Employee() { firstName = "Khoa", lastName = "Dang", Id = 125};
            //Compare using the operator "=="
            Console.WriteLine("Is employee 1 the same as the employee 2: " + (emp1 == emp2));
            //Compare using the operator "!="
            Console.WriteLine("Is employee 2 different than the employee 3: " + (emp2 != emp3));
            Console.ReadLine();
        }
    }
}
