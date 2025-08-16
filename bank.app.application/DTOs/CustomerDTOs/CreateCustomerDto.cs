using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.DTOs.CustomerDTOs
{
    public class CreateCustomerDto
    {
        [Required]
        public string FullName { get; set; }

        [Required, MaxLength(11)]
        public string NationalId { get; set; }

        [Required]
        public string BirthPlace { get; set; }
    }
}
