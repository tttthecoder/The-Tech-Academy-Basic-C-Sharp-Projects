using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)

        {
            //Create all 10 employees.
            Employee emp1 = new Employee() { Id = 1, firstName = "Tin", lastName = "Tran" };
            Employee emp2 = new Employee() { Id = 2, firstName = "Dang", lastName = "Khoa" };
            Employee emp3 = new Employee() { Id = 3, firstName = "Joe", lastName = "Pham" };
            Employee emp4 = new Employee() { Id = 4, firstName = "Joe", lastName = "Nguyen" };
            Employee emp5 = new Employee() { Id = 5, firstName = "Joe", lastName = "Tran" };
            Employee emp6 = new Employee() { Id = 6, firstName = "Andrew", lastName = "Tran" };
            Employee emp7 = new Employee() { Id = 7, firstName = "Andrew", lastName = "nguyen" };
            Employee emp8 = new Employee() { Id = 8, firstName = "Ngoc", lastName = "Tran" };
            Employee emp9 = new Employee() { Id = 9, firstName = "Hao", lastName = "Vu" };
            Employee emp10 = new Employee() { Id = 10, firstName = "Giang", lastName = "Nguyen" };
            //Put them in a list.
            List<Employee> listOfEmployee = new List<Employee>
            {
                emp1,
                emp2,
                emp3,
                emp4,
                emp5,
                emp6,
                emp7,
                emp8,
                emp9,
                emp10
            };
            //Create a list of employees whose firstNames are Joe.
            //With a loop.
            List<Employee> result1 = new List<Employee>();
            foreach (Employee emp in listOfEmployee)
            {
                if (emp.firstName == "Joe")
                {
                    result1.Add(emp);
                }
            }
            List<Employee> Joes = listOfEmployee.Where(x => x.firstName == "Joe").ToList();
            //Create a list of employees whose Id's are greater than 5.
            List<Employee> result2 = listOfEmployee.Where(x => x.Id > 5).ToList();

            Console.ReadLine();
        }

    }
    public class Employee
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
