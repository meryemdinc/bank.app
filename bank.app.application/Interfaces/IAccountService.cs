using bank.app.application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountDto>> GetAllAsync();
        Task<AccountDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateAccountDto createDto);
        Task<bool> UpdateAsync(UpdateAccountDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
