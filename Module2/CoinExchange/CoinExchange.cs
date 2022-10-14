// Write a program that will prompt the user for a number for dollars and cents.  

// Taking the number from the user, display the number of quarters, dimes, nickels,
// and pennies to make that amount, using the least total number of coins possible.
// Nobody wants a pocketful of pennies!


// Restrictions:

// You cannot use anything past Chapter 05
// This means you cannot use loops, arrays, methods, or create your own classes
// You cannot use any collection classes
// This means you cannot use Lists, Dictionaries, etc
// You cannot use any NuGet packages
// Any built-in libraries, like System.Math, is fine

using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the amount of money to be exchanged: ");
            double amountOfMoney =  Convert.ToDouble(Console.ReadLine());

            int numberOfQuarters = Convert.ToInt32(Math.Floor(amountOfMoney / .25));
            amountOfMoney -= (numberOfQuarters * .25);

            int numberOfDimes = Convert.ToInt32(Math.Floor(amountOfMoney / .1));
            amountOfMoney -= (numberOfDimes * .1);

            int numberOfNickels = Convert.ToInt32(Math.Floor(amountOfMoney / .05));
            amountOfMoney -= (numberOfNickels * .05);

            int numberOfPennies = Convert.ToInt32(amountOfMoney / 0.01);

            Console.WriteLine("{0} quarters, {1} dimes, {2} nickel, {3} pennies",numberOfQuarters, numberOfDimes, numberOfNickels, numberOfPennies);
        }
    }
}
