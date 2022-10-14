using System;
using System.Threading.Channels;
using Microsoft.VisualBasic.CompilerServices;

namespace Module6
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Select an operation.\n1) AddValues\n2) SubtractValues\n3) MultiplyValues\n4) DivideValues\n5) RemainderValues\n");
			string userChoice = Console.ReadLine();
			Console.WriteLine("Enter a number.");
			string valueOne = Console.ReadLine();
			Console.WriteLine("Enter another number.");
			string valueTwo = Console.ReadLine();

			try
			{
				switch (userChoice)
				{
					case "1":
						Console.WriteLine($"Result={AddValues(valueOne, valueTwo)}");
						break;
					case "2":
						Console.WriteLine($"Result={SubtractValues(valueOne, valueTwo)}");
						break;
					case "3":
						Console.WriteLine($"Result={MultiplyValues(valueOne, valueTwo)}");
						break;
					case "4":
						Console.WriteLine($"Result={DivideValues(valueOne, valueTwo)}");
						break;
					case "5":
						Console.WriteLine($"Result={RemainderValues(valueOne, valueTwo)}");
						break;
					default:
						break;
				}
			}
			catch (OverflowException ex)
            {
				// Handle Exception
            }
			catch (DivideByZeroException ex)
            {
				// Handle Exception
            }
			catch (FormatException ex)
            {
				// Handle Exception
            }
			catch (Exception ex)
            {
				// Handle Exception
            }
			
		}
		static int AddValues(string valueOne, string valueTwo)
		{
			int parsedValueOne = int.Parse(valueOne);
			int parsedValueTwo = int.Parse(valueTwo);
			return parsedValueOne + parsedValueTwo;
		}

		static int SubtractValues(string valueOne, string valueTwo)
		{
			int parsedValueOne = int.Parse(valueOne);
			int parsedValueTwo = int.Parse(valueTwo);
			return parsedValueOne - parsedValueTwo;
		}

		static int MultiplyValues(string valueOne, string valueTwo)
		{
			int parsedValueOne = int.Parse(valueOne);
			int parsedValueTwo = int.Parse(valueTwo);
			return parsedValueOne * parsedValueTwo;
		}

		static int DivideValues(string valueOne, string valueTwo)
		{
			int parsedValueOne = int.Parse(valueOne);
			int parsedValueTwo = int.Parse(valueTwo);
			return parsedValueOne / parsedValueTwo;
		}

		static int RemainderValues(string valueOne, string valueTwo)
		{
			int parsedValueOne = int.Parse(valueOne);
			int parsedValueTwo = int.Parse(valueTwo);
			return parsedValueOne % parsedValueTwo;
		}
	}
}