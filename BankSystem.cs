using System;
using System.Collections.Generic;
using System.Linq;
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
        Quit
    }

    internal class BankSystem
    {
        static void Main(string[] args)
        {
            Account jimCBA = new Account("Jim", 100.10);

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
                    Console.WriteLine("4. Quit");
                    Console.Write("Enter your choice (1-4): ");

                    string input = Console.ReadLine();
                    bool validInt = int.TryParse(input, out choice);

                    if (validInt && choice >= 1 && choice <= 4)
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
                if (double.TryParse(input, out double amount))
                {
                    account.withdraw(input);
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
                if (double.TryParse(input, out double amount))
                {
                    account.deposit(input);
                }
                else
                {
                    Console.WriteLine("Please enter a valid amount.");
                }
            }

            static void DoPrint(Account account)
            {
                account.print();
            }
        }
        
    }
}
         
        