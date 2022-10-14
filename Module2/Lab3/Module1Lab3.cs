// Lab 3 - Console Inputs
// Create a “mad lib” that asks the user for various pieces of information. Store the 
// information as strings.Once the information has been collected, output a story using the
// stored information.

using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a past tense verb.");
            string verb = Console.ReadLine();

            Console.WriteLine("Please enter a noun.");
            string noun = Console.ReadLine();

            Console.WriteLine("Please enter an adjective.");
            string adjetive = Console.ReadLine();

            Console.WriteLine("I was {0} {1} to {2}!", adjetive, verb, noun);
        }
    }
}
