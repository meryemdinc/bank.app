using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.application.DTOs.CustomerDTOs
{
    public class UpdateCustomerDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, MaxLength(11)]
        public string NationalId { get; set; }


    }
}
