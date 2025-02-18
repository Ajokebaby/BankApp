using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Request
{
    public  class TransactionRequestDto
    {
        [Required(ErrorMessage ="Account number cannot be empty")]
       // [StringLength(10, MinimumLength = 10, ErrorMessage = "Account number must be exactly 10 characters")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }
    }
}
