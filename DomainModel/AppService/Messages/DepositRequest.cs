using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.AppService.Messages
{
    public class DepositRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}