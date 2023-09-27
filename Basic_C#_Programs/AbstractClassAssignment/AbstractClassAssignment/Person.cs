using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassAssignment
{
    //keyword abstract make the Person class an abstract class which cannot be instantiated.
    abstract class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        //abstract keyword make the method SayName() an abstract method which cannot have an implementation.
        public abstract void SayName();
    }
    
}




