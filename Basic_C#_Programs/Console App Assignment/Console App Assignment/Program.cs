using System;
using System.Collections.Generic;

namespace Console_App_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //assignment part 1
            Console.WriteLine("------------------part 1--------------------");
            //initialize the array
            string[] names = new string[] { "Tin", "Peter", "Adam", "John" };
            //Ask for user input
            Console.WriteLine("Enter a last name you think is cool: ");
            string lastName;
            lastName = Console.ReadLine();
            //Loop through the array and modify each item.
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i] + " " + lastName;
            }
            //Loop through the array and print the item
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            //Assignment parts 2 and 3
            Console.WriteLine("------------------parts 2 and 3--------------------");
            //create an infinite loop
            //for (int i = 0; i < names.Length;)
            //{
            //    names[i] = names[i] + " " + lastName;
            //    Console.WriteLine(names[i]);
            //}
            //fix the infinite loop by incrementing the loop variable i and this is also demonstrating a loop with the
            //terminating condition with an < operator.
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i] + " " + lastName;
                Console.WriteLine(names[i]);
            }
            //this while loop only loops through the first 2 elements of the array and demonstrates how to terminate a loop with the "<=" operator.
            int j = 0;
            while (j <= 1)
            {
                Console.WriteLine(names[j]);
                j++;

            }
            //Assignment part 4
            Console.WriteLine("------------------part 4--------------------");
            List<string> uniqueList = new List<string>() { "Dog", "Cat", "Mouse", "Dragon", "Elephant", "Ant" };
            //Ask for user input
            Console.WriteLine("Enter one of your favorite animals: ");
            string inputAnimal = Console.ReadLine();
            //Set the boolean to false, this value will keep track of if we have found the item in the list.
            bool foundAnimal = false;
            //Loop through the list to find the item.
            foreach (string animal in uniqueList)
            {
                if (animal.ToLower() == inputAnimal.ToLower())
                {
                    //Once an animal has been found, we have to update the boolean value to indicate we have found the item.
                    foundAnimal = true;
                    Console.WriteLine("Here is the item for the animal: " + animal);
                    //This code is for breaking the loop once the animal has been found.
                    break;
                }
            }
            //if none of the items in the list match the search term we tell that to user. 
            if (foundAnimal != true)
            {
                Console.WriteLine("Sorry, your search could not be found.");
            }
            //Assignment part 5
            Console.WriteLine("------------------part 5--------------------");
            List<string> notUniqueList = new List<string>() { "Dog", "Dog", "Cat", "Mouse", "Fly", "Fly", "Dragon", "Chicken", "Elephant", "Ant", "Chicken", "Fly" };
            //Ask for user input
            Console.WriteLine("Enter one of your favorite animals: ");
            string inputAnimal2 = Console.ReadLine();
            //Set the boolean to false, this value will keep track of if we have found the item in the list.
            bool foundAnimal2 = false;
            //Loop through the list to find the item.
            for (int i = 0; i < notUniqueList.Count; i++)
            {
                if (notUniqueList[i].ToLower() == inputAnimal2.ToLower())
                {
                    //Once an animal has been found, we have to update the boolean value to indicate we have found the item.
                    foundAnimal2 = true;
                    Console.WriteLine("Here is the index in the list for the animal: " + i);
                }
            }
            //if none of the items in the list matched the search term, we notify the user. 
            if (foundAnimal2 != true)
            {
                Console.WriteLine("Sorry, your search could not be found.");
            }

            //Assignment part 6
            Console.WriteLine("------------------part 6--------------------");
            //We do not need to create another list, but we do need to create an empty list to store all the values we have encountered.
            List<string> encounteredValues = new List<string>();
            //Loop through the list to process each item.
            foreach (string animal in notUniqueList)
            {
                //if we have encountered the item, we then display it accordingly.
                if (encounteredValues.Contains(animal))
                {
                    Console.WriteLine(animal + " - This item is a duplicate");
                }
                //if not, we should add the newly discovered item into the encounteredValues list and display the item accordingly.
                else
                {
                    encounteredValues.Add(animal);
                    Console.WriteLine(animal + " - This item is unique");
                }
            }
            Console.ReadLine();
        }
    }
}
