using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.DTOs.CardDTOs
{
    public class UpdateCardDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string CCV { get; set; }
        public bool IsActive { get; set; }
        public int CardTypeId { get; set; }
        public int AccountId { get; set; }
    }
}
