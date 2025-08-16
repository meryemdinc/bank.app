using AutoMapper;
using bank.app.application.DTOs.AccountDTOs;
using bank.app.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bank.app.application.Mapping
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // Entity → DTO
            CreateMap<Account, AccountDto>();

            // DTO → Entity (Create)
            CreateMap<CreateAccountDto, Account>();

            // DTO → Entity (Update)
            CreateMap<UpdateAccountDto, Account>();

            // Entity → DTO (Update için geri dönüş gerekiyorsa)
            CreateMap<Account, UpdateAccountDto>();
        }
    }
}
