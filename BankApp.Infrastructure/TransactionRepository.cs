using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;
using BankApp.Domain.Request;
using BankApp.Domain.Response;

namespace BankApp.Infrastructure
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<CustomerInformation> _accounts;
        public TransactionRepository()
        {

            _accounts = new List<CustomerInformation>
        {
            new CustomerInformation { AccountNumber = "1234589439", AccountName = "Alice", Balance = 10000 },
            new CustomerInformation { AccountNumber = "011345194", AccountName = "Bob", Balance = 20000 }
        };
        }
        public AccountBalanceResponseDto CheckBalance(string accountNumber)
        {
            var response = new AccountBalanceResponseDto();
            try
            {
                var getBalance = _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
                if (getBalance == null)
                {
                    response.Balance = null;
                   response.AccountName = null;
                    response.Message = "Account not found";
                    return response;    

                }

                response.Balance = getBalance.Balance.ToString("N");
                response.AccountName = getBalance.AccountName;
                response.Message = "SUCCESS";
                response.IsSuccess = true;  
                return response;
                
            }
            catch (Exception ex)
            {


                throw;
            }
            
        }

        public TransactionResponseDto DepositAmount(TransactionRequestDto request)
        {
            var response = new TransactionResponseDto();
            try
            {
                if(request.AccountNumber.Length > 10)
                {
                    response.Message = "Account number should be 10 digit";
                    response.NewBalance = null;
                    return response;
                }
                var getAccountDetails = _accounts.FirstOrDefault(x => x.AccountNumber == request.AccountNumber);
                if (getAccountDetails == null)
                {
                    response.Message = "Account not found";
                    response.NewBalance = null;
                    return response;    

                }
                getAccountDetails.Balance += request.Amount;
                response.Message = "SUCCESS";
                response.NewBalance = getAccountDetails.Balance.ToString("N");
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
           

        }

        public TransactionResponseDto WithdrawAmount(TransactionRequestDto request)
        {
            var response = new TransactionResponseDto();
            try
            {
                if (request.AccountNumber.Length > 10)
                {
                    response.Message = "Account number should be 10 digit";
                    response.NewBalance = null;
                    return response;
                }
                var getAccountDetails = _accounts.FirstOrDefault(x => x.AccountNumber == request.AccountNumber);
                if (getAccountDetails == null)
                {
                    response.Message = "Account not found";
                    response.NewBalance = null;
                    return response;

                }
                if(getAccountDetails.Balance < request.Amount)
                {
                    response.Message = "Insufficient balance";
                    response.NewBalance = null;
                    return response;
                }
                getAccountDetails.Balance -= request.Amount;
                response.Message = "SUCCESS";
                response.NewBalance = getAccountDetails.Balance.ToString("N");
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
