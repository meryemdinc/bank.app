using bank.app.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Repositories
{

    public interface IAccountRepository : IRepository<Account>
    {
        // İhtiyaç olursa ekstra özel metotlar eklenebilir
        Task<Account> GetWithDetailsAsync(int id);  // Örnek: transaction veya kartlarla birlikte çekme
    }
}
