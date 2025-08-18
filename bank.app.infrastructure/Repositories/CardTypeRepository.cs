using bank.app.domain.Entities;
using bank.app.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Repositories
{
    public class CardTypeRepository : EfRepository<CardType>, ICardTypeRepository
    {
        public CardTypeRepository(BankDbContext context) : base(context)
        {
        }
    }


}
