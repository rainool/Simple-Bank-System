using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static BankSystem.BankSystem;

namespace BankSystem
{
    internal enum MenuOption
    {
        Withdraw,
        Deposit,
        Print,
        Transfer,
        Quit
    }

    internal class BankSystem
    {
        static void Main(string[] args)
        {
            Account jimCBA = new Account("Jim", 1025.80);
            
            Account oscarNAB = new Account("Oscar", 550.20);

            MenuOption userOption;
            do
            {
                userOption = ReadUserOption();

                switch (userOption)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(jimCBA);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(jimCBA);
                        break;
                    case MenuOption.Print:
                        DoPrint(jimCBA);
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(jimCBA, oscarNAB);
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Quitting.....");
                        break;
                }
                Console.WriteLine("\n-----------------------------------\n");
            } while (userOption != MenuOption.Quit);

            static MenuOption ReadUserOption()
            {
                int choice;
                do
                {
                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine("1. Withdraw");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Print");
                    Console.WriteLine("4. Transfer");
                    Console.WriteLine("5. Quit");
                    Console.Write("Enter your choice (1-5): ");

                    string input = Console.ReadLine();
                    bool validInt = int.TryParse(input, out choice);

                    if (validInt && choice >= 1 && choice <= 5)
                    {
                        return (MenuOption)(choice - 1);
                    }
                    Console.WriteLine("Invalid option. Please try again.\n");

                } while (true);
            }

            static void DoWithdraw(Account account)
            {
                Console.WriteLine("Enter withdrawal amount: ");
                string input = Console.ReadLine();
                
                if (decimal.TryParse(input, out decimal amount) && amount >= 0)
                {
                    var transaction = new WithdrawTransaction(account, amount);
                    try
                    {
                        transaction.Execute();
                        transaction.Print();

                        Console.WriteLine("\nDo you want to reverse this transaction? (y/n): ");
                        string rollbackInput = Console.ReadLine();
                        if (rollbackInput.Trim().ToLower() == "y")
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch(InvalidOperationException ex)
                            {
                                Console.WriteLine($"Rollback error: {ex.Message}");
                            }
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Error detected: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid amount.");
                }
            }

            static void DoDeposit(Account account)
            {
                Console.WriteLine("Enter deposit amount: ");
                string input = Console.ReadLine();

                
                if (decimal.TryParse(input, out decimal amount))
                {
                    var transaction = new DepositTransaction(account, amount);
                    try
                    {
                        transaction.Execute();
                        transaction.Print();

                        Console.WriteLine("\nDo you want to reverse this transaction? (y/n): ");
                        string rollbackInput = Console.ReadLine();
                        if (rollbackInput.Trim().ToLower() == "y")
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Rollback error: {ex.Message}");
                            }
                        }

                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Error detected: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid amount.");
                }
            }

            static void DoTransfer(Account fromAccount, Account toAccount)
            {
                Console.WriteLine($"Transfer from {fromAccount.Name} to {toAccount.Name}");
                Console.WriteLine("Enter transfer amount: ");

                string input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal amount) && amount > 0)
                {
                    var transaction = new TransferTransaction(fromAccount, toAccount, amount);
                    try
                    {
                        transaction.Execute();
                        transaction.Print();

                        Console.WriteLine("\nDo you want to reverse this transaction? (y/n): ");
                        string rollbackInput = Console.ReadLine();
                        if (rollbackInput.Trim().ToLower() == "y")
                        {
                            try
                            {
                                transaction.Rollback();
                                Console.WriteLine("Rollback successful.");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Rollback error: {ex.Message}");
                            }
                        }
                        
                        
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Error detected: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid, positive amount.");
                }
            }

            static void DoPrint(Account account)
            {
                account.print();
            }
        }

    }
}

