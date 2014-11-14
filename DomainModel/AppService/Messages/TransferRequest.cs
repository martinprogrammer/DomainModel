using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.AppService.Messages
{
    public class TransferRequest
    {
        public Guid AccountIdTo { get; set; }
        public Guid AccountIdFrom { get; set; }
        public decimal Amount { get; set; }
    }
}