using AutoMapper;
using bank.app.application.DTOs.CardDTOs;
using bank.app.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bank.app.application.Mapping
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDto>().ReverseMap();
            CreateMap<Card, CreateCardDto>().ReverseMap();
            CreateMap<Card, UpdateCardDto>().ReverseMap();
        }
    }

}
