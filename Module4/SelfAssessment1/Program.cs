using System;

namespace selfassessment1
{
    class Program
    {
        // Method that finds the maximal value of two ints. Returns the maximal int. 
        static int GetMax(int number1, int number2)
        {
            return Math.Max(number1, number2);
        }

        // Methat that takes in an int, finds the last digit in the int, and returns the English
        // name of the last digit (ie. 1 = "one, 2 = "two, etc).
        static string NumberSpeltOut(int number1)
        {
            int numberLength = number1.ToString().Length;
            int lastNumber = Convert.ToInt32(number1 % Math.Pow(10, numberLength -1));

            switch (lastNumber)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return number1.ToString();
            }
        }

        // Method that iterates through an int array and looks for the first number that is greater than 
        // the previous element and the element proceeding it. If there is such a number, it will return
        // the index of that number. Else, it will return -1. 
        static int IndexOfFirstNumberGreaterThanAdjacentNumbers(int[] numArray)
        {
            for(int i = 0; i < numArray.Length; i++)
            {
                // Since the first and last elements of an array don't have 2 neighboring elements, we
                // avoid those elements. 
                if (i > 0 && i < numArray.Length - 1)
                {
                    if ((numArray[i] > numArray[i + 1]) && (numArray[i] > (numArray[i - 1])))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int number1 = 1;
            int number2 = 100008;

            int max_num = GetMax(number1, number2);
            Console.Write(max_num);

            string lastDigit = NumberSpeltOut(number2);
            Console.Write("\n{0}", lastDigit);

            int[] numArray = new int[] {1,2,3,4,5,6,7,8,9,10};
            int index = IndexOfFirstNumberGreaterThanAdjacentNumbers(numArray);
            Console.WriteLine("\n{0}", index);
        }
    }
}
