using System;

namespace selfassessment3
{
    class Program
    {
        static void SquareRoot()
        {
            Console.WriteLine("Please enter a number that you would like to find the square root of: ");
            try
            {
                int initialNumber = Convert.ToInt32(Console.ReadLine());
                double sqrtOfNumber = Math.Sqrt(initialNumber);
                Console.WriteLine(sqrtOfNumber);
            }
            catch
            {
                Console.WriteLine("Invalid Number");
            }
            finally
            {
                Console.WriteLine("Good Bye");
            }
        }

        static void ReadNumber(int start, int end)
        {
            Console.WriteLine("Please enter an integer: ");

        }
        
        static void Main(string[] args)
        {
            SquareRoot();
        }
    }
}
