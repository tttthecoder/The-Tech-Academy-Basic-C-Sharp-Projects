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
    }
}
