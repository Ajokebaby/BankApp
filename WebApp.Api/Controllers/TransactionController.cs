using BankApp.Domain.Request;
using BankApp.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpPost("deposit")]
        public IActionResult Deposit([FromBody] TransactionRequestDto request)
        {
            var response = _transactionRepository.DepositAmount(request);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw([FromBody] TransactionRequestDto request)
        {
            var response = _transactionRepository.WithdrawAmount(request);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("balance/{accountNumber}")]
        public IActionResult GetBalance(string accountNumber)
        {
            var response = _transactionRepository.CheckBalance(accountNumber);
            if (response.IsSuccess)
                return Ok(response);

            return NotFound(new { Message = "Account not found" });
        }
    }
}
