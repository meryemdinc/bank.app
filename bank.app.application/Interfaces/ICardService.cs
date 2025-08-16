using bank.app.application.DTOs.CardDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.Interfaces
{
    public interface ICardService
    {
        Task<IEnumerable<CardDto>> GetAllAsync();
        Task<CardDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateCardDto dto);
        Task<bool> UpdateAsync(UpdateCardDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
