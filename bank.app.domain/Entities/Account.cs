using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace bank.app.domain.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string AccountName { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required, MaxLength(26)]
        public string IBAN { get; set; }

        public DateTime OpenedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // CardId tek bir kartı değil, genellikle bir hesabın birden fazla kartı olabileceği düşünülür.
        // Eğer bir hesaba ait birden fazla kart varsa CardId yerine sadece Cards koleksiyonu yeterlidir.
        // Tek bir karta aitse, o zaman CardId'nin mantığı değişebilir.
        // Şu anki yapıda Cards koleksiyonu yeterli görünüyor.
        // public int CardId { get; set; } // Bu satırı kaldırdım, genellikle buna ihtiyaç duyulmaz.
        public virtual ICollection<Card> Cards { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public Account() { }

        public Account(DateTime openedAt, bool isActive)
        {
            OpenedAt = openedAt;
            IsActive = isActive;
        }
    }
    }
