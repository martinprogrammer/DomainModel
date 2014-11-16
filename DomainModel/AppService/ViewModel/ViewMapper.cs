using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace DomainModel.AppService.ViewModel
{
    public class ViewMapper
    {
        public static TransactionView CreateTransactionViewFrom(Transaction tran)
        {
            return new TransactionView
            {
                Deposit = tran.Deposit.ToString("C"),
                Withdrawal = tran.Withdrawal.ToString("C"),
                Reference = tran.Reference,
                Date = tran.Date
            };
        }

        public static BankAccountView CreateBankAccountViewFrom(BankAccount acc)
        {
            return new BankAccountView
            {
                AccountNo = acc.AccountNo,
                Balance = acc.Balance.ToString("C"),
                CustomerRef = acc.CustomerRef,
                Transactions = new List<TransactionView>()
            };
        }

        public static BankAccountsDropdownView CreateBankAccountDropdownViewFrom(IEnumerable<BankAccount> accounts)
        {
            BankAccountsDropdownView view = new BankAccountsDropdownView();
            List<SelectListItem> theList = new List<SelectListItem>();

            theList.Add(new SelectListItem
            {
                Text = "Select Bank Account",
                Value = "-1",

            });

            foreach (BankAccount acc in accounts)
            {
                theList.Add(new SelectListItem
                {
                    Text = acc.CustomerRef,
                    Value = acc.AccountNo.ToString()
                });
            }

          

            view.bankAccounts = theList;
            return view;

        }
    }
}