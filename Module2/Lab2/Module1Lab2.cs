// Lab 2 - Inputs
// Ask the user for the following info:
// Favorite Season
// Favorite Car
// Favorite TV Show
// How much they spent on streaming services last year
// Give them a response using all of their info in one statement at the end using string
// formatting.Use currency formatting when you display the cable bill. 

using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your favorite season?");
            string favoriteSeason = Console.ReadLine();

            Console.WriteLine("What is your favorite car?");
            string favoriteCar = Console.ReadLine();

            Console.WriteLine("What is your favorite TV show?");
            string favoriteTvShow = Console.ReadLine();

            Console.WriteLine("How did you spend on streaming services last year?");
            float cableBill = float.Parse(Console.ReadLine());

            Console.WriteLine("I see that you entered {0}, {1}, {2}, and {3:C2}!", favoriteSeason, favoriteCar, favoriteTvShow, cableBill);
        }
    }
}
