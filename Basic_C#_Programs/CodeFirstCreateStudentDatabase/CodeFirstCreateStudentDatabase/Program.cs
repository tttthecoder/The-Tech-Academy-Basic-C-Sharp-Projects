using System;
using System.Data.Entity;
using System.Linq;
namespace CodeFirstCreateStudentDatabase
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                //Create and save a new Student
                Console.WriteLine("Enter a first name for a new Student: ");
                var name = Console.ReadLine();

                var student = new Student { FirstName = name };
                db.Students.Add(student);
                db.SaveChanges();


                //Display all the Student from the database
                var studentList = from s in db.Students
                                  orderby s.FirstName
                                  select s;

                Console.WriteLine("All Students in the database");
                foreach (var s in studentList)
                {
                    Console.WriteLine(s.FirstName);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal GPA { get; set; }
        public string EmailAddress { get; set; }
    }

    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
