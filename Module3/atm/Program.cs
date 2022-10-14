using System;
using System.IO;

namespace atm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****   ATM   *****\n");

            // Get the user's account number and verify that it is correct. If not, continue to ask until they enter the correct number.
            string accountNumber = "12345";
            Console.WriteLine("Please enter your 5-digit Account Number: ");
            string userAccountNumberResponse = Console.ReadLine();

            while (userAccountNumberResponse != accountNumber)
            {
                Console.WriteLine("You entered the wrong Account Number. Please enter your Account Number: ");
                userAccountNumberResponse = Console.ReadLine();
            }


            // Get the user's PIN and verify that it is correct. If not, continue to ask until they enter the correct PIN.
            string pin = "0000";
            Console.WriteLine("\nPlease enter your 4-digit PIN : ");
            string userPinResponse = Console.ReadLine();

            while (userPinResponse != pin)
            {
                Console.WriteLine("You entered the wrong PIN. Please enter your PIN: ");
                userPinResponse = Console.ReadLine();
            }


            // Diplay the banking menu for the user and ask them what actions would they like to take. Validate that the input from the user
            // or prompt them to re-enter their response. 
            bool validOptionSelected = false;
            while (validOptionSelected == false)
            {
                Console.WriteLine("\nBanking Menu:\n----------\nDeposit\nWithdrawal\nExit\n");
                Console.WriteLine("Please select what you would like to do: ");
                string userMenuSelection = Console.ReadLine();

                if (userMenuSelection == "Deposit")
                {
                    double amountDeposited;
                    bool validDepositAmount = false;

                    while (validDepositAmount == false)
                    {
                        Console.WriteLine("How much would you like to deposit? ");
                        try
                        {
                            amountDeposited = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("${0} has been deposited into account number {1}.", amountDeposited, accountNumber);
                            validDepositAmount = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please enter a numerical value");
                            using(StreamWriter logFile = new StreamWriter("DepositLogFile.txt"))
                            {
                                logFile.WriteLine("Message:");
                                logFile.WriteLine(ex.Message);
                                logFile.WriteLine("\nInner Exception:");
                                logFile.WriteLine(ex.InnerException);
                                logFile.WriteLine("\nStackTrace:");
                                logFile.WriteLine(ex.StackTrace);
                                logFile.Close();

                            }
                        }
                    }
                    
                }
                else if (userMenuSelection == "Withdrawal")
                {
                    double amountWithdrawn;
                    bool validWithdrawnAmount = false;

                    while (validWithdrawnAmount == false)
                    {
                        Console.WriteLine("How much would you like to withdraw? ");
                        try
                        {
                            amountWithdrawn = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("${0} has been withdrawn from account number {1}.", amountWithdrawn, accountNumber);
                            validWithdrawnAmount = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please enter a numerical value");
                            using (StreamWriter logFile = new StreamWriter("WithdrawalLogFile.txt"))
                            {
                                logFile.WriteLine("Message:");
                                logFile.WriteLine(ex.Message);
                                logFile.WriteLine("\nInner Exception:");
                                logFile.WriteLine(ex.InnerException);
                                logFile.WriteLine("\nStackTrace:");
                                logFile.WriteLine(ex.StackTrace);
                                logFile.Close();

                            }
                        }
                    }
                }
                else if (userMenuSelection == "Exit")
                {
                    Console.WriteLine("We appreciate your business! Have a great day!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("I'm sorry, but I don't understand your request. Please select what you'd like to do.");
                }
            }
        }
    }
}
