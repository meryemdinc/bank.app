using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.DTOs.TransactionDTOs
{
    public class CreateTransactionDto
    {
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        public int? AccountId { get; set; }
        public int? CardId { get; set; }

        public int TransactionTypeId { get; set; }
    }
}
