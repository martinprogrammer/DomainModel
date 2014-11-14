using DomainModel.AppService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.AppService.Messages
{
    public class FindAllBankAccountResponse : ResponseBase
    {
        public IList<BankAccountView> BankAccountView { get; set; }
    }
}