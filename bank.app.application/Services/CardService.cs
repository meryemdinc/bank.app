using AutoMapper;
using bank.app.application.DTOs.CardDTOs;
using bank.app.application.Interfaces;
using bank.app.domain.Entities;
using bank.app.infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.Services
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CardDto>> GetAllAsync()
        {
            var cards = await _unitOfWork.Cards.GetAllAsync();
            return _mapper.Map<IEnumerable<CardDto>>(cards);
        }

        public async Task<CardDto> GetByIdAsync(int id)
        {
            var card = await _unitOfWork.Cards.GetByIdAsync(id);
            return _mapper.Map<CardDto>(card);
        }

        public async Task<bool> CreateAsync(CreateCardDto dto)
        {
            var card = _mapper.Map<Card>(dto);
            await _unitOfWork.Cards.AddAsync(card);
            var affected = await _unitOfWork.SaveChangesAsync();
            return affected > 0;
        }


        public async Task<bool> UpdateAsync(UpdateCardDto dto)
        {
            var existing = await _unitOfWork.Cards.GetByIdAsync(dto.Id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            _unitOfWork.Cards.Update(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var card = await _unitOfWork.Cards.GetByIdAsync(id);
            if (card == null) return false;

            _unitOfWork.Cards.Delete(card);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
