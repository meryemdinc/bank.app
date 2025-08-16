using AutoMapper;
using bank.app.application.DTOs.CustomerDTOs;
using bank.app.application.Interfaces;
using bank.app.domain.Entities;
using bank.app.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bank.app.application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return customer == null ? null : _mapper.Map<CustomerDto>(customer);
        }

        public async Task<bool> CreateAsync(CreateCustomerDto createDto)
        {
            if (createDto == null)
                throw new ArgumentNullException(nameof(createDto), "createDto is null");

            // DTO'dan direkt Entity'ye map ediyoruz
            var customer = _mapper.Map<Customer>(createDto);

            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateCustomerDto updateDto)
        {
            var existing = await _repository.GetByIdAsync(updateDto.Id);
            if (existing == null) return false;

            // DTO'dan direkt Entity'ye map ediyoruz
            _mapper.Map(updateDto, existing);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            _repository.Delete(existing);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
