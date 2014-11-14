using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public class BankAccount
    {
        private IList<Transaction>_transactions;
        private decimal _balance;
        private string _customerRef;
        private Guid _accountNo;
        

        public BankAccount() : this(Guid.NewGuid(), 0,
        new List<Transaction>(), "")
        {
            _transactions.Add(new Transaction(0m, 0m, "account created", DateTime.Now));
        }

        public BankAccount(Guid id, decimal balance, IList<Transaction> transactions, string customerRef)
        {
            _accountNo = id;
            _balance = balance;
            _transactions = transactions;
            _customerRef = customerRef;
        }

        [Key]
        public Guid AccountNo
        {
            get { return _accountNo; }
            internal set {_accountNo = value;}
        }

        public decimal Balance
        {
            get { return _balance; }
            internal set {_balance = value;}
        }

        public string CustomerRef
        {
            get { return _customerRef; }
            internal set {_customerRef = value;}
        }

        public bool CanWithdraw(decimal amount)
        {
            return amount >= _balance;
        }

        public void Withdraw(decimal amount, string reference)
        {
            if (CanWithdraw(amount))
            {
                _balance -= amount;
                _transactions.Add(new Transaction(0m, amount, reference, DateTime.Now));
            }
            else
                throw new InsufficientFundsException();
        }

        public void Deposit(decimal amount, string reference)
        {
            _balance += amount;
            _transactions.Add(new Transaction(amount, 0m, reference, DateTime.Now));
        }

        public IEnumerable<Transaction>GetTransactions()
        {
            return _transactions;
        }
    }
}