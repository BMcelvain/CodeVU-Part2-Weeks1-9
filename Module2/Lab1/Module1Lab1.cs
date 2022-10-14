//Lab 1 - Data Types
//Declare and initialize 10 different data types Use at least: 
// 1 string 
// 1 integer type 
// 1 floating point type
// 1 bool
// 1 char
// Display each of them with a Console.WriteLine();

using System;

namespace module1
{
    class Program
    {
        static void Main(string[] args)
        {
            char alpha = 'A';
            bool havingFun = true;
            string userName = "Brett McElvain";
            float pi = 3.14f;
            ushort slightlyBiggerNumber = 500;
            short slightlyBiggerNegativeNumber = -500;
            uint evenBiggerNumber = 50_000;
            int evenBiggerNegativeNumber = -50_000;
            ulong reallyBigNumber = 500_000_000_000;
            long reallyBigNegativeNumber = -500_000_000_000;

            Console.WriteLine(alpha);
            Console.WriteLine(havingFun);
            Console.WriteLine(userName);
            Console.WriteLine(pi);
            Console.WriteLine(slightlyBiggerNumber);
            Console.WriteLine(slightlyBiggerNegativeNumber);
            Console.WriteLine(evenBiggerNumber);
            Console.WriteLine(evenBiggerNegativeNumber);
            Console.WriteLine(reallyBigNumber);
            Console.WriteLine(reallyBigNegativeNumber);
        }
    }
}
