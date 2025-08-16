using bank.app.application.DTOs.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllAsync();
        Task<TransactionDto> GetByIdAsync(int id);
        Task<IEnumerable<TransactionDto>> GetByAccountIdAsync(int accountId);
        Task<bool> CreateAsync(CreateTransactionDto dto);
        Task<bool> UpdateAsync(int id, UpdateTransactionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
