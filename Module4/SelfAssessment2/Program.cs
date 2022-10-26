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

        static double AverageOfNumbers (int numberFromUser)
        {
            char[] numbersSeperated = numberFromUser.ToString().ToCharArray();
            double count = 1;
            double total = 0;

            foreach (char c in numbersSeperated)
            {
                count++;
                total += c;
            }

            return total/count;
        }

        static int LinearEquation (int a, int b, int x)
        {
            return (a*x)+b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to do? ");
            Console.WriteLine("Menu:\n----------");
            Console.WriteLine("1. Reverse Number Sequence");
            Console.WriteLine("2. Calculate Average of Number Sequence");
            Console.WriteLine("3. Linear Equation: [(a*x)+b] ");
            Console.WriteLine("4. Exit");

            string userSelection = Console.ReadLine();    
            bool invalidResponse = true;

            switch(userSelection)
            { 
                case "1": 
                    while(invalidResponse)
                    { 
                        Console.WriteLine("Please enter a number to reverse: ");
                        try
                        {
                            int userNumber = Convert.ToInt32(Console.ReadLine());
                            if (userNumber < 1 || userNumber > 50_000_000)
                            {
                                Console.WriteLine("Please enter a whole number between 1 and 50,000,000.");
                            }
                            else
                            {
                                int reversedNumber = ReverseNumber(userNumber);
                                Console.WriteLine(reversedNumber);
                                invalidResponse = false;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Please enter a whole number.");
                        }
                        catch (OverflowException ex)
                        {
                            Console.WriteLine("Please enter a smaller whole number.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }
                    break;

                case "2":
                    while(invalidResponse)
                    { 
                        Console.WriteLine("Please enter a number sequence that you would like to find the average of: ");
                        try
                        {
                            int userNumber = Convert.ToInt32(Console.ReadLine());
                            if (userNumber < 1 || userNumber > 50_000_000)
                            {
                                Console.WriteLine("Please enter a whole number between 1 and 50,000,000.");
                            }
                            else
                            {
                                double average = AverageOfNumbers(userNumber);
                                Console.WriteLine(average);
                                invalidResponse = false;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Please enter a whole number.");
                        }
                        catch (OverflowException ex)
                        {
                            Console.WriteLine("Please enter a smaller whole number.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }
                    break;

                case "3":
                    while(invalidResponse)
                    {   
                        Console.WriteLine("Please enter 3 numbers on one line (ie:1 2 3). The first number is (a), the second is (b), and the third is (x): ");
                        try
                        {
                            string[] userNumbers = Console.ReadLine().Split();
                            int count = 0;
                            int numA;
                            int numB;
                            int numX;

                            foreach (string userNumber in userNumbers)
                            {   
                                 int userNum = Convert.ToInt32(userNumber);
                                 if (userNum < 1 || userNum > 50_000_000)
                                 {
                                    Console.WriteLine("Please enter a whole number between 1 and 50,000,000.");
                                 }
                                 else
                                 {
                                    if (count == 0)
                                    {
                                        numA = userNum;
                                        count++;
                                    }
                                    else if (count == 1)
                                    {
                                        numB = userNum;
                                        count++;
                                    }
                                    else if (count == 2)
                                    {
                                        numX = userNum;
                                        count++;
                                    }
                                 }
                            }

                            invalidResponse = false;
                            // double linearEquation = LinearEquation(numA, numB, numX);
                            Console.WriteLine();
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Please enter a whole number.");
                        }
                        catch (OverflowException ex)
                        {
                            Console.WriteLine("Please enter a smaller whole number.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }
                    break;

                case "4":
                    break;

                    
                    
            }
        }
    }
}
