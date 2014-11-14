using DomainModel.AppService.Messages;
using DomainModel.Models;
using DomainModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.AppService
{
    public class ApplicationBankAccountService
    {
        private BankAccountService _bankAccountService;
        private IBankAccountRepository _bankRepository;

        public ApplicationBankAccountService() : this (new BankAccountRepository(), new BankAccountService(new BankAccountRepository()))
        { }

        public ApplicationBankAccountService(IBankAccountRepository repository, BankAccountService service)
        {
            _bankAccountService = service;
            _bankRepository = repository;
        }

        public BankAccountCreateResponse CreateBankAccount(BankAccountCreateRequest bankAccountCreateRequest)
        {
            BankAccountCreateResponse bankAccountCreateResponse = new BankAccountCreateResponse();
            BankAccount bankAccount = new BankAccount();

            bankAccount.CustomerRef = bankAccountCreateRequest.CustomerName;
            _bankRepository.Add(bankAccount);

            return bankAccountCreateResponse;
        }

        public void Deposit(DepositRequest depositRequest)
        {
            BankAccount bankAccount = _bankRepository.Find(depositRequest.AccountId);
            bankAccount.Deposit(depositRequest.Amount, "");
            _bankRepository.Save(bankAccount);
        }

        public void Deposit(WithdrawalRequest withdrawalRequest)
        {
            BankAccount bankAccount = _bankRepository.Find(withdrawalRequest.AccountId);
            bankAccount.Withdraw(withdrawalRequest.Amount, "");
            _bankRepository.Save(bankAccount);
        }

        public TransferResponse Transfer(TransferRequest request)
        {

        }
    }
}