using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DomainModel.Repository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private SQLDbContext myContext;

        public BankAccountRepository() : this(new SQLDbContext())
        { }

        public BankAccountRepository(SQLDbContext context)
        {
            myContext = context;
        }

        public void Add(BankAccount bankAccount)
        {
            myContext.BankAccounts.Add(bankAccount);
        }


        public void Save(BankAccount bankAccount)
        {
            myContext.SaveChanges();
        }

        public IEnumerable<BankAccount> FindAll()
        {
            return myContext.BankAccounts;
        }

        public BankAccount Find(Guid AccountId)
        {
            return myContext.BankAccounts.Where(p => p.AccountNo == AccountId).SingleOrDefault();
        }

        
    }
}