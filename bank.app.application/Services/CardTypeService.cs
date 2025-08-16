using AutoMapper;
using bank.app.application.DTOs.CardTypeDTOs;
using bank.app.application.Interfaces;
using bank.app.domain.Entities;
using bank.app.infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bank.app.application.Services
{
    public class CardTypeService : ICardTypeService
    {
        private readonly ICardTypeRepository _repository;
        private readonly IMapper _mapper;

        public CardTypeService(ICardTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CardTypeDto>> GetAllAsync()
        {
            var cardTypes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CardTypeDto>>(cardTypes);
        }

        public async Task<CardTypeDto> GetByIdAsync(int id)
        {
            var cardType = await _repository.GetByIdAsync(id);
            return cardType == null ? null : _mapper.Map<CardTypeDto>(cardType);
        }

        public async Task<CardTypeDto> CreateAsync(CreateCardTypeDto dto)
        {
            // DTO'dan direkt Entity'ye map ediyoruz
            var cardType = _mapper.Map<CardType>(dto);

            await _repository.AddAsync(cardType);
            await _repository.SaveChangesAsync();
            return _mapper.Map<CardTypeDto>(cardType);
        }

        public async Task<CardTypeDto> UpdateAsync(UpdateCardTypeDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return null;

            // DTO'dan direkt entity'ye map ediyoruz
            _mapper.Map(dto, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<CardTypeDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
