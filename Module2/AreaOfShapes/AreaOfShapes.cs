// https://canvas.instructure.com/courses/5030193/pages/out-of-class-exercise-area-of-shapes?module_item_id=69015008
//
// Restrictions:

// You cannot use anything past Chapter 05
// This means you cannot use loops, arrays, methods, or create your own classes
// You cannot use any collection classes
// This means you cannot use Lists, Dictionaries, etc
// You cannot use any NuGet packages
// Any built-in libraries, like System.Math, is fine

using System;

namespace areaofshapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a shape:\nTriangle\nQuadrilateral\nCircle\n");
            string shapeChosen = Console.ReadLine();

            if (shapeChosen == "Triangle")
            {
                // Gather the length 3 sides of a triangle from the user.
                Console.WriteLine("\nPlease enter the length of the side 1: ");
                double triangleSide1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nPlease enter the length of the side 2: ");
                double triangleSide2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nPlease enter the length of the side 3: ");
                double triangleSide3 = Convert.ToDouble(Console.ReadLine());

                // Determine the shortest, middle, and longest sides of the triangle.
                double shortestSide = Math.Min(Math.Min(triangleSide1, triangleSide2), triangleSide3);
                double longestSide = Math.Max(Math.Max(triangleSide1, triangleSide2), triangleSide3);

                double middleSide;
                if ((triangleSide2 < triangleSide1 && triangleSide1 < triangleSide3) || (triangleSide3 < triangleSide1 && triangleSide1 < triangleSide2))
                {
                    middleSide = triangleSide1;
                }
                else if ((triangleSide1 < triangleSide2 && triangleSide2 < triangleSide3) || (triangleSide3 < triangleSide2 && triangleSide2 < triangleSide1))
                {
                    middleSide = triangleSide2;
                }
                else
                {
                    middleSide = triangleSide3;
                }

                // Determine the type of triangle.
                if (Math.Pow(shortestSide, 2) + Math.Pow(middleSide, 2) > Math.Pow(longestSide, 2))
                {
                    Console.WriteLine("Acute Triangle");
                }
                else if (Math.Pow(shortestSide, 2) + Math.Pow(middleSide, 2) == Math.Pow(longestSide, 2))
                {
                    Console.WriteLine("Right Triangle");
                }
                else
                {
                    Console.WriteLine("Obtuse Triangle");
                }

                // Determine the Area of the triangle
                double semiPerimeter = (shortestSide + middleSide + longestSide) / 2;
                double areaOfTriangle = Math.Sqrt(semiPerimeter * (semiPerimeter - shortestSide) * (semiPerimeter - middleSide) * (semiPerimeter - longestSide));
                Console.WriteLine(areaOfTriangle);
            }
            else if (shapeChosen == "Quadrilateral")
            {
                // Gather the length of 4 sides of a quadrilateral from the user. 
                Console.WriteLine("\nPlease enter the length of side 1: ");
                double quadSide1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nPlease enter the length of side 2: ");
                double quadSide2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nPlease enter the length of side 3: ");
                double quadSide3 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nPlease enter the length of side 4: ");
                double quadSide4 = Convert.ToDouble(Console.ReadLine());

                // Determine the type of quadrilateral.
                string typeOfQuad;
                if (quadSide1 == quadSide2 && quadSide2 == quadSide3 && quadSide3 == quadSide4)
                {
                    Console.WriteLine("Square");
                    typeOfQuad = "Square";
                }
                else if ((quadSide1 != quadSide2 && quadSide2 != quadSide3 && quadSide3 == quadSide1 && quadSide1 == quadSide3))
                {
                    Console.WriteLine("Rectangle");
                    typeOfQuad = "Rectangle";
                }
                else
                {
                    Console.WriteLine("Trapezoid");
                    typeOfQuad = "Trapezoid";
                }

                // Determine the area of the quadrilateral. 
                if (typeOfQuad == "Square")
                {
                    Console.WriteLine(Math.Pow(quadSide1, 2));
                }
                else if (typeOfQuad == "Rectangle")
                {
                    double rectLength = Math.Max(Math.Max(Math.Max(quadSide1, quadSide2), quadSide3), quadSide4);
                    double rectWidth = Math.Min(Math.Min(Math.Min(quadSide1, quadSide2), quadSide3), quadSide4);

                    Console.WriteLine(rectWidth * rectLength);
                }
                else
                {
                    Console.WriteLine("Please enter the height of the Trapezoid");
                    double trapHeight = Convert.ToDouble(Console.ReadLine());

                    // Determine unique sides.
                    double trapUniqueSide1;
                    double trapUniqueSide2;

                    if (quadSide1 == quadSide2)
                    {
                        trapUniqueSide1 = quadSide3;
                        trapUniqueSide2 = quadSide4;
                    }
                    else if (quadSide1 == quadSide3)
                    {
                        trapUniqueSide1 = quadSide2;
                        trapUniqueSide2 = quadSide4;
                    }
                    else if (quadSide1 == quadSide4)
                    {
                        trapUniqueSide1 = quadSide2;
                        trapUniqueSide2 = quadSide3;
                    }
                    else if (quadSide2 == quadSide3)
                    {
                        trapUniqueSide1 = quadSide1;
                        trapUniqueSide2 = quadSide4;
                    }
                    else if (quadSide2 == quadSide4)
                    {
                        trapUniqueSide1 = quadSide1;
                        trapUniqueSide2 = quadSide3;
                    }
                    else
                    {
                        trapUniqueSide1 = quadSide1;
                        trapUniqueSide2 = quadSide2;
                    }

                    Console.WriteLine(((1.0 / 2.0) * (trapUniqueSide1 + trapUniqueSide2) * trapHeight));
                }
            }
            else
            {
                Console.WriteLine("Please enter the radius of the Circle: ");
                double circleRadius = Convert.ToDouble(Console.ReadLine());

                double circleArea = Math.PI * Math.Pow(circleRadius, 2);
                if (circleArea < 100)
                {
                    Console.WriteLine("Little Circle");
                }
                else
                {
                    Console.WriteLine("Big Circle");
                }

                Console.WriteLine(circleArea);
            }
            
        }
    }
}
