using System;

namespace selfassessment2
{
    class Program
    {
        static int ReverseNumber (int numberToReverse)
        {
            char[] reversedNumberArray = numberToReverse.ToString().ToCharArray();
            Array.Reverse(reversedNumberArray);
            string reversedNumber = "";

            foreach (char c in reversedNumberArray)
            {
                reversedNumber += c;
            }
            return Convert.ToInt32(reversedNumber);
        }
        static void Main(string[] args)
        {
            int number = 1234;
            Console.WriteLine(ReverseNumber(number));
        }
    }
}
