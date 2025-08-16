using bank.app.application.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateCustomerDto dto);
        Task<bool> UpdateAsync(UpdateCustomerDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
