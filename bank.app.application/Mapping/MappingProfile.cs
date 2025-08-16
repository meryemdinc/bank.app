using AutoMapper;
using bank.app.application.DTOs.AccountDTOs;
using bank.app.application.DTOs.CardDTOs;
using bank.app.application.DTOs.CardTypeDTOs;
using bank.app.application.DTOs.CustomerDTOs;
using bank.app.application.DTOs.TransactionDTOs;
using bank.app.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            // Account Mapping
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<CreateAccountDto, Account>();
            CreateMap<UpdateAccountDto, Account>();

            // Card Mapping
            CreateMap<Card, CardDto>().ReverseMap();
            CreateMap<CreateCardDto, Card>();
            CreateMap<UpdateCardDto, Card>();

            // Transaction Mapping
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<CreateTransactionDto, Transaction>();
            CreateMap<UpdateTransactionDto, Transaction>();

            // CardType Mapping
            CreateMap<CardType, CardTypeDto>().ReverseMap();
            CreateMap<CreateCardTypeDto, CardType>();
            CreateMap<UpdateCardTypeDto, CardType>();
        }
    }
}
