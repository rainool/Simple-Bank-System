using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed = false, _success = false, _reversed = false;

        public WithdrawTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public void Print()
        {
            Console.WriteLine("Withdraw Transaction Details");
            Console.WriteLine($"Account: {_account.Name}");
            Console.WriteLine($"Withdrawal Amount: {_amount.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");
            Console.WriteLine($"Account Balance: {_account.Balance.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");

            Console.WriteLine("\n---WITHDRAWAL-STATUS---");
            Console.WriteLine($"Execution Status: {_executed}");
            Console.WriteLine($"Success Status: {_success}");
            Console.WriteLine($"Reversal Status: {_reversed}");
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Transaction already executed.");
            }

            _executed = true;
            if((decimal)_account.Balance >= _amount)
            {
                _account.Balance -= (double)_amount;
                _success = true;
            }
            else
            {
                _success = false;
                throw new InvalidOperationException("Insufficient Funds.");
            }
        }

        public void Rollback()
        {
            if (!_executed)
            {
                throw new InvalidOperationException("Transaction not executed.");
            }
            if (!_success)
            {
                throw new InvalidOperationException("Cannot reverse unsuccessful transaction");
            }
            if (_reversed)
            {
                throw new InvalidOperationException("Transaction already reversed");
            }

            _account.Balance += (double)_amount;
            _reversed = true;
        }

        public bool Executed => _executed;
        public bool Success => _success;
        public bool Reversed => _reversed;


    }
}
