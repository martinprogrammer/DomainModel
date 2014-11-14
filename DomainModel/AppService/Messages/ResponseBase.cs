using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.AppService.Messages
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}