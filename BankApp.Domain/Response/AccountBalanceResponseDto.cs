using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Response
{
    public  class AccountBalanceResponseDto
    {
        public AccountBalanceResponseDto()
        {
                IsSuccess = false;  
        }
        public string Balance { get; set; }
        public string AccountName { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
