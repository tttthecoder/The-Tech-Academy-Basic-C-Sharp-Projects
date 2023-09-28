using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassAssignment
{
    //Employee class inherits from Person class
    class Employee : Person, IQuittable
    {
        public int Id { get; set; }
        //Actual implementation of the SayName() abstract method. This sastisfies the contract with the abstract parent class.  
        public override void SayName()
        {
            Console.WriteLine("My name: {0} {1}", firstName, lastName);
        }
        //Actual implementation of the Quit() interface method. This sastisfies the contract with the interface IQuittable.  
        public void Quit()
        {
            Console.WriteLine("Hi boss, I want to quit this job");
        }
        //Overload the operator "==" by using the Id attribute for comparision
        public static bool operator== (Employee emp1, Employee emp2)
        {
            return emp1.Id == emp2.Id;
        }
        //Overload the operator "!=" by using the Id attribute for comparision
        public static bool operator != (Employee emp1, Employee emp2)
        {
            return emp1.Id != emp2.Id;
        }
    }
}
