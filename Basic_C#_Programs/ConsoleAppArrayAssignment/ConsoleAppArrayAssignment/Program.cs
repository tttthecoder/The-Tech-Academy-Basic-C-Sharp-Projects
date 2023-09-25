using System;
using System.Collections.Generic;

namespace ConsoleAppArrayAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //This create and initialize a string array.
            string[] strArray = new string[] { "Jessie", "John", "Tom", "Peter" };
            //Ask for user input.
            Console.WriteLine("What index you want to choose? ");
            int chosenIndex = Convert.ToInt32(Console.ReadLine());
            //check for valid index.
            if ((strArray.Length - 1) < chosenIndex || chosenIndex < 0)
            {
                Console.WriteLine("Sorry, the index was out of range.");

            }
            else
            {
                Console.WriteLine("Here is the result from string array: " + strArray[chosenIndex]);

            }
            //This create and initialize a int array.
            int[] strArray2 = new int[] { 4, 5, 6, 76, 7, 7 };
            //Ask for user input.
            Console.WriteLine("What index you want to choose? ");
            int chosenIndex2 = Convert.ToInt32(Console.ReadLine());
            //check for valid index.
            if ((strArray2.Length - 1) < chosenIndex2 || chosenIndex2 < 0)
            {
                Console.WriteLine("Sorry, the index was out of range.");

            }
            else
            {
                Console.WriteLine("Here is the result from int array: " + strArray2[chosenIndex2]);

            }

            //Create a list of string
            List<string> strList = new List<string>();
            //Populate the list.
            strList.Add("Tom");
            strList.Add("Joshep");
            strList.Add("Josh");
            strList.Add("Tammy");
            //Ask for user input.

            Console.WriteLine("What index you want to choose for the list? ");
            int chosenIndex3 = Convert.ToInt32(Console.ReadLine());
            //check for valid index.
            if ((strList.Count - 1) < chosenIndex3 || chosenIndex3 < 0)
            {
                Console.WriteLine("Sorry, the index was out of range.");

            }
            else
            {
                Console.WriteLine("Here is the result from list: " + strList[chosenIndex3]);

            }

            Console.ReadLine();
        }
    }
}
