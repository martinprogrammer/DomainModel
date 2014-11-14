﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public class Transaction
    {
        public Transaction(decimal deposit, decimal withdrawal, string reference, DateTime date)
        {
            this.Deposit = deposit;
            this.Withdrawal = withdrawal;
            this.Reference = reference;
            this.Date = date;
        }
        public decimal Deposit { get; set; }
        public decimal Withdrawal { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
    }
}