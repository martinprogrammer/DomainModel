using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DomainModel.Models
{
    public class DatabaseInitialiser : DropCreateDatabaseIfModelChanges<SQLDbContext>
    {
        protected override void Seed(SQLDbContext context)
        {
            context.BankAccounts.Add(new BankAccount
            {
                AccountNo = Guid.NewGuid(),
                Balance = 200M,
                CustomerRef = "hapy"
            });
            context.BankAccounts.Add(new BankAccount
            {
                AccountNo = Guid.NewGuid(),
                Balance = 100M,
                CustomerRef = "chapy"
            });
            context.BankAccounts.Add(new BankAccount
            {
                AccountNo = Guid.NewGuid(),
                Balance = 800M,
                CustomerRef = "wind"
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}