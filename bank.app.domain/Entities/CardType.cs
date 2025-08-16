using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.domain.Entities
{
    public class CardType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
