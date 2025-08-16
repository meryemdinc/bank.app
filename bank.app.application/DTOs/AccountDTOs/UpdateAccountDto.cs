using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.DTOs.AccountDTOs
{
    public class UpdateAccountDto
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string AccountName { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required, MaxLength(26)]
        public string IBAN { get; set; }

        public bool IsActive { get; set; }
    }
}
