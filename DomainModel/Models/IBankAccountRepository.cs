using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public interface IBankAccountRepository
    {
        void Add(BankAccount bankAccount);
        void Save(BankAccount bankAccount);
        IEnumerable<BankAccount> FindAll();
        BankAccount Find(Guid AccountId);

    }
}