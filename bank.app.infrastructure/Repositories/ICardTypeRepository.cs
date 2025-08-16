using bank.app.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Repositories
{
    public interface ICardTypeRepository : IRepository<CardType>
    {
        // Özel sorgular olursa buraya eklenebilir
    }
}
