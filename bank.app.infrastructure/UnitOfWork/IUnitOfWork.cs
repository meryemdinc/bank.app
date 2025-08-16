using bank.app.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        ICardRepository Cards { get; }
        ICustomerRepository Customers { get; }
        ITransactionRepository Transactions { get; }

        // SaveChangesAsync, değişen kayıt sayısını döndürür.
        Task<int> SaveChangesAsync();
    }
}
