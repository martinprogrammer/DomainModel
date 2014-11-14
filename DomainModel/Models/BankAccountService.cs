using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public class BankAccountService
    {
        private IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public void Transfer(Guid accountNoTo, Guid accountNoFrom, decimal amount)
        {
            BankAccount bankAccountTo = _bankAccountRepository.Find(accountNoTo);
            BankAccount bankAccountFrom = _bankAccountRepository.Find(accountNoFrom);
            if (bankAccountFrom.CanWithdraw(amount))
            {
                bankAccountFrom.Withdraw(amount, "Transfer to acc " + bankAccountTo.CustomerRef);
                bankAccountTo.Deposit(amount, "Transfer from acc " + bankAccountFrom.CustomerRef);

                _bankAccountRepository.Save(bankAccountTo);
                _bankAccountRepository.Save(bankAccountFrom);
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }
    }
}