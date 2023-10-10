using System;

namespace Scores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter in your first name.");
            string date = DateTime.Today.ToLongDateString();
            string uName = Console.ReadLine();

            string msg = $"\nWelcome back {uName}. Today is {date}.";
            string path = @"C:\Users\Admin\Desktop\The-Tech-Academy-Basic-C-Sharp-Projects\Basic_C#_Programs\Scores\Scores\Scores.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            double totalScores=0;
            Console.WriteLine(msg);
            Console.WriteLine("\nStudent Scores: \n");
            foreach (string line in lines)
            {
                Console.WriteLine("\n"+ line);
                totalScores += Convert.ToDouble(line);
            }
            Console.Write("\nTotal of "+ lines.Length +" student scores.\tAverage score: "+ (totalScores / lines.Length));
            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
