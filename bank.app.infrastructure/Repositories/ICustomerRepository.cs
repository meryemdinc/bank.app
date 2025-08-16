using bank.app.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        // Özel metot gerekiyorsa eklenebilir
    }
}
