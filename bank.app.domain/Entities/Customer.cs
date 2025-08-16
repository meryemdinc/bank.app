using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.domain.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }// her müşterinin benzersiz kimliği var

        [Required, MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required, MaxLength(11)]
        public string NationalId { get; set; } = null!;

        [Required]
        public string BirthPlace { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public decimal RiskLimit { get; set; } = 10000;//müşteriye tanımlanan risk limiti

        public ICollection<Account> Accounts { get; set; } = new List<Account>();//bü müşteriye ait hesapların koleksiyonu 
    }

}
