// Lab 4 - Casting
// Some variables to use
// byte puddle = 100;
// short pond = 29456;
// int lake = 100000; //one hundred thousand
// long ocean = 5;
// For each casting, include a comment categorizing it as:
// implicit casting
// explicit casting
// explicit casting with truncation
// REMEMBER.... Right TO Left thinking.... 
// 1. Cast the value of lake into ocean and display it 
// 2. Cast the value of pond into puddle and display it 
// 3. Cast the value of pond into ocean and display it 
// 4. Cast the value of ocean into lake and display it
 

using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            byte puddle = 100;
            short pond = 29456;
            int lake = 100_000; 
            long ocean = 5;

            ocean = (long)lake;         // Implicit casting (smaller to larger data type).
            Console.WriteLine(ocean);

            puddle = (byte)pond;        // Explicit cating with truncation (larger to smaller data type).
            Console.WriteLine(puddle);

            ocean = (long)pond;         // Implicit casting (smaller to larger date type).
            Console.WriteLine(ocean);

            lake = (int)ocean;          // Explicit casting (larger to smaller data type).
            Console.WriteLine(lake);
        }
    }
}
