using bank.app.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(int accountId);
        Task<IEnumerable<Transaction>> GetByCardIdAsync(int cardId);
        // Gerekirse başka özel sorgular burada tanımlanabilir.
    }
}
