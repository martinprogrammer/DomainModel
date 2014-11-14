using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel.AppService.ViewModel;

namespace DomainModel.AppService.Messages
{
    public class FindBankAccountResponse : ResponseBase
    {
        public BankAccountView BankAccount { get; set; }
    }
}