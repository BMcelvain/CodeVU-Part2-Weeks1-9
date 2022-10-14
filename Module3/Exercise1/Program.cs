using System;
using System.Linq;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] userInput = Convert.ToInt32(Console.ReadLine());
            //int[] userInput = {45, 23, 44, 68, 65, 70, 80, 81, 82};

            //for (int i = 0; i < userInput.Length - 3; i++)
            //{
            //    var test = userInput.Skip(i).Take(3);
            //    
            //}
            StudentGrade();
        }

        static void StudentGrade()
        {
            // "4\n5\n3\n6\n3\n7\n4\n8\n3\n5";

            float[,] students = new float[2,5];

            for(int i = 0; i < 5 ; i++)
            {
                students[0,i] = Convert.ToSingle(Console.ReadLine());
            }
            for (int i = 0; i < 5; i++)
            {
                students[1, i] = Convert.ToSingle(Console.ReadLine());
            }

            float avgGroup1 = 0;
            float avgGroup2 = 0;
            for (int i = 0; i < 5; i++)
            {
                avgGroup1 += students[0, i];
            }
            for (int i = 0; i < 5; i++)
            {
                avgGroup2 += students[1, i];
            }

            Console.WriteLine("{0}", avgGroup1/5);
            Console.WriteLine("{0}", avgGroup2/5);
        }
    }
}
