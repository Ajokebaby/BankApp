using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Response
{
    public class TransactionResponseDto
    {
        public TransactionResponseDto()
        {
                IsSuccess = false;
        }
        public string Message { get; set; }
        public string NewBalance { get; set; }
        public bool IsSuccess { get; set; }
    }
}
