using bank.app.application.DTOs.CardTypeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.Interfaces
{
    public interface ICardTypeService
    {
        Task<IEnumerable<CardTypeDto>> GetAllAsync();
        Task<CardTypeDto> GetByIdAsync(int id);
        Task<CardTypeDto> CreateAsync(CreateCardTypeDto dto);
        Task<CardTypeDto> UpdateAsync(UpdateCardTypeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
