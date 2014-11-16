using DomainModel.AppService.Messages;
using DomainModel.AppService.ViewModel;
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
            TransferResponse response = new TransferResponse();

            try
            {
                _bankAccountService.Transfer(request.AccountIdTo, request.AccountIdFrom, request.Amount);
                response.Success = true;
            }
            catch(InsufficientFundsException)
            {
                response.Message = "There is not enough funds in account no: " + request.AccountIdFrom.ToString();
                response.Success = false;
            }

            return response;
        }

        public FindAllBankAccountResponse GetAllBankAccounts()
        {
            FindAllBankAccountResponse FindAllBankAccountResponse = new FindAllBankAccountResponse();
            IList<BankAccountView> bankAccountViews = new List<BankAccountView>();
            FindAllBankAccountResponse.BankAccountView = bankAccountViews;
            foreach(BankAccount acc in _bankRepository.FindAll())
            {
                bankAccountViews.Add(
                    ViewMapper.CreateBankAccountViewFrom(acc));
            }

            return FindAllBankAccountResponse;
        }

        public FindBankAccountResponse GetBankAccountBy(Guid id)
        {
            // new FindBankAccountResponse object
            FindBankAccountResponse bankAccountResponse = new FindBankAccountResponse();

            // return account from repository
            BankAccount acc = _bankRepository.Find(id);

            // that account convert into BankAccountView
            BankAccountView bankAccountView = ViewMapper.CreateBankAccountViewFrom(acc);

            // iterate through account GetTransactions()
            foreach(Transaction tran in acc.GetTransactions())
            {
                // add transactions to BankAccountView
                bankAccountView.Transactions.Add(
                    ViewMapper.CreateTransactionViewFrom(tran));
            }

            // bankAccoiuntResponse.BankAccount = bankAccountView
            bankAccountResponse.BankAccount = bankAccountView;

            return bankAccountResponse;
        }

        public  BankAccountsDropdownView GetAccountsDropdown(string acc)
        {
            BankAccountsForDropdownResponse theResponse = new BankAccountsForDropdownResponse();
            IEnumerable<BankAccount> accounts = _bankRepository.FindAll();

            BankAccountsDropdownView theView = ViewMapper.CreateBankAccountDropdownViewFrom(accounts);

            theResponse.bankAccounts = theView;

            return theResponse.bankAccounts;


            
        }
    }
}