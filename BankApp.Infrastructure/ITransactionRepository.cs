using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain.Request;
using BankApp.Domain.Response;

namespace BankApp.Infrastructure
{
    public  interface ITransactionRepository
    {
        TransactionResponseDto DepositAmount(TransactionRequestDto request);
        TransactionResponseDto WithdrawAmount(TransactionRequestDto request);
        AccountBalanceResponseDto CheckBalance(string accountNumber);
    }
}
