using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace bank.app.domain.Entities
{
    public class Card : IEntity
    {
        public int Id { get; set; }//her kart için benzersiz bir id

        [Required, MaxLength(16)]
        public string CardNumber { get; set; } = null!;

        [Required]
        public int ExpiryMonth { get; set; }

        [Required]
        public int ExpiryYear { get; set; }

        [Required, MaxLength(3)]
        public string CCV { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public int CardTypeId { get; set; }
        public virtual CardType? CardType { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();//bu karta ait işlemlerin koleksiyonu
    }

}
