﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.AppService.ViewModel
{
    public class TransactionView
    {
        public string Deposit { get; set; }
        public string Withdrawal { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
    }
}