using AutoMapper;
using bank.app.application.DTOs.AccountDTOs;
using bank.app.application.Interfaces;
using bank.app.domain.Entities;
using bank.app.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bank.app.application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<List<AccountDto>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return _mapper.Map<List<AccountDto>>(accounts);
        }

        public async Task<AccountDto> GetByIdAsync(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null) return null;
            return _mapper.Map<AccountDto>(account);
        }

        public async Task<bool> CreateAsync(CreateAccountDto createDto)
        {
            // DTO'dan direkt Entity'ye map ediyoruz
            var account = _mapper.Map<Account>(createDto);

            await _accountRepository.AddAsync(account);
            await _accountRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateAccountDto updateDto)
        {
            var existingAccount = await _accountRepository.GetByIdAsync(updateDto.Id);
            if (existingAccount == null) return false;

            // DTO'dan direkt entity'ye map ediyoruz
            _mapper.Map(updateDto, existingAccount);
            await _accountRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingAccount = await _accountRepository.GetByIdAsync(id);
            if (existingAccount == null) return false;

            _accountRepository.Delete(existingAccount);
            await _accountRepository.SaveChangesAsync();
            return true;
        }
    }
}
