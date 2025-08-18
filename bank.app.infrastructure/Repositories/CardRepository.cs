using bank.app.domain.Entities;
using bank.app.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Repositories
{
    public class CardRepository : EfRepository<Card>, ICardRepository
    {
        public CardRepository(BankDbContext context) : base(context)
        {
        }
    }
}
