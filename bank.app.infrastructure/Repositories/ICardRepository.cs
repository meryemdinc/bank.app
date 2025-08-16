using bank.app.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        // İstersen buraya özel sorgular ekleyebilirsin, örneğin:
        // Task<IEnumerable<Card>> GetActiveCardsByCustomerIdAsync(int customerId);
    }
}
