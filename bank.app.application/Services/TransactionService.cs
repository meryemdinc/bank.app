using AutoMapper;
using bank.app.application.DTOs.TransactionDTOs;
using bank.app.application.Interfaces;
using bank.app.domain.Entities;
using bank.app.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public async Task<TransactionDto> GetByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<IEnumerable<TransactionDto>> GetByAccountIdAsync(int accountId)
        {
            var transactions = await _transactionRepository.GetByAccountIdAsync(accountId);
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public async Task<bool> CreateAsync(CreateTransactionDto dto)
        {
            var transaction = _mapper.Map<Transaction>(dto);
            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(int id, UpdateTransactionDto dto)
        {
            var existing = await _transactionRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            _mapper.Map(dto, existing);
            _transactionRepository.Update(existing);
            await _transactionRepository.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _transactionRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            _transactionRepository.Delete(existing);
            await _transactionRepository.SaveChangesAsync();
            return true;
        }
    }
}
