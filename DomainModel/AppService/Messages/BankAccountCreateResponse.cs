using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.AppService.Messages
{
    public class BankAccountCreateResponse : ResponseBase
    {
        public Guid BankAccountId { get; set; }
    }
}