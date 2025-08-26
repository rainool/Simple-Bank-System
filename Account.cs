using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class Account
    {
        //Instance variables
        private string _name;
        private double _balance = 0.0;

        //Constructor
        public Account(string name, double balance)
        {
            this._name = name;
            this._balance = balance;
        }


        //validation methods
        public bool validateDbl(string userInput)
        {
            return double.TryParse(userInput, out double validated);
        }



        //methods
        public void deposit(string input)
        {
            double depositAmount = Convert.ToDouble(input);
            if (depositAmount >= 0)
            {
                _balance += depositAmount;
                Console.WriteLine("Successfully deposited " + depositAmount.ToString("C", CultureInfo.GetCultureInfo("en-US"))
                    + "\nCurrent account balance: " + _balance.ToString("C", CultureInfo.GetCultureInfo("en-US")));
            }
            else if (depositAmount < 0)
            {
                Console.WriteLine("Invalid amount.");
            }
        }



        public void withdraw(string input)
        {
            double withdrawalAmount = Convert.ToDouble(input);
            if (withdrawalAmount >= 0 && withdrawalAmount <= _balance)
            {
                _balance -= withdrawalAmount;
                Console.WriteLine("Successfully withdrawn " + withdrawalAmount.ToString("C", CultureInfo.GetCultureInfo("en-US"))
                    + "\nCurrent account balance: " + _balance.ToString("C", CultureInfo.GetCultureInfo("en-US")));
            }
            else if (withdrawalAmount > _balance)
            {
                Console.WriteLine("Insufficient funds."
                    + "\nCurrent account balance: " + _balance.ToString("C", CultureInfo.GetCultureInfo("en-US")));
            }
            else if (withdrawalAmount < 0)
            {
                Console.WriteLine("Please enter a valid amount");
            }
        }



        public void print()
        {
            Console.WriteLine("Account Name: " + _name
                + "\nAccount Balance: " + _balance.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        }



        public string Name
        {
            get { return _name; }
        }

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
    }
}
