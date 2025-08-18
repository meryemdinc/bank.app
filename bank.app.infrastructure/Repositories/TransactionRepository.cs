using bank.app.domain.Entities;
using bank.app.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Repositories
{
    public class TransactionRepository : EfRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(BankDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(int accountId)
        {
            return await _context.Transactions
                .Include(t => t.TransactionType)
                .Where(t => t.AccountId == accountId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetByCardIdAsync(int cardId)
        {
            return await _context.Transactions
                .Include(t => t.TransactionType)
                .Where(t => t.CardId == cardId)
                .ToListAsync();
        }
    }
}
