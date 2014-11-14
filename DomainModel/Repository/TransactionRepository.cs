using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.Repository
{
    public class TransactionRepository
    {
        SQLDbContext myContext;

        public TransactionRepository(SQLDbContext context)
        {
            myContext = context;
        }

        public void Add(Guid bankAccount, decimal deposit, decimal withdrawal, string reference)
        {
            myContext.Transactions.Add(new Transaction(deposit, withdrawal, reference, DateTime.Now));
               
          

        }
    }
}