using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class TransferTransaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private bool _executed = false;
        private bool _success = false;
        private bool _reversed = false;

        public bool Executed => _executed;
        public bool Reversed => _reversed;
        public bool Success => _deposit.Success && _withdraw.Success;

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;

            _withdraw = new WithdrawTransaction(_fromAccount, _amount);
            _deposit = new DepositTransaction(_toAccount, _amount);
        }

        public void Print()
        {
            Console.WriteLine($"\n{_amount.ToString("C", CultureInfo.GetCultureInfo("en-US"))} has been transferred " +
                $"from {_fromAccount.Name}'s to {_toAccount.Name}'s account.\n");

            Console.WriteLine("---Transfer-Details---");
            _withdraw.Print();
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Transfer has already been executed.");
            }

            try
            {
                _withdraw.Execute();
                _deposit.Execute();
                _executed = true;
                
                if(_withdraw.Success && _deposit.Success)
                {
                    _success = true;
                }
            }
            catch(InvalidOperationException ex)
            {
                throw new InvalidOperationException("Transfer failed: " + ex.Message);
            }
        }

        public void Rollback()
        {
            if (!_executed)
            {
                throw new InvalidOperationException("Transfer not executed yet.");
            }
            if (!_success)
            {
                throw new InvalidOperationException("Cannot reverse unsuccessful transfer.");
            }
            if (_reversed)
            {
                throw new InvalidOperationException("Transfer already reversed.");
            }

            try
            {
                _deposit.Rollback();
                _withdraw.Rollback();
                _reversed = true;
            }
            catch(InvalidOperationException ex)
            {
                throw new InvalidOperationException("Rollback failed: " + ex.Message);
            }
        }
    }
}
