using Checkout.Db.Models;
using Checkout.Gateway.Api.Interfaces;
using Checkout.Gateway.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Gateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly ITransactionService _transactionService;
        private readonly IBankService _bankService;

        public TransactionController(ICurrencyService currencyService,
            ITransactionService transactionService,
            IBankService bankService)
        {
            _currencyService = currencyService;
            _transactionService = transactionService;
            _bankService = bankService;
        }

        // POST: api/<TransactionController>
        [HttpPost]
        public async Task<IActionResult> ProcessTransaction(PaymentRequest paymentRequest)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (paymentRequest.Amount <= 0) {
                return BadRequest("Amount should be non-negative");
            }

            var currency = await _currencyService.GetCurrency(paymentRequest.Currency);
            if (currency == null) 
            { 
                return BadRequest("Invalid Currency");
            }                   

            var status = await _bankService.HandleTransaction(paymentRequest);

            // TODO
            // check if card deatils exists in the database by card number
            // update other fields if nessesary
            // id card details doesn't exist - add them to the database
            // use it instead of below line
            var cardDetails = new Db.Models.CardDetails();

            var transaction = new Db.Models.Transaction
            {
                Amount = paymentRequest.Amount,
                Created = DateTime.UtcNow,
                CurrencyId = currency.CurrencyId,
                CardDetailsId = cardDetails.CardDetailsId,
                Status = status,
            };

            transaction = await _transactionService.SaveTransaction(transaction);

            if (status == TransactionStatus.Ok)
            {
                return Ok(transaction);
            }
            else 
            {
                return BadRequest(transaction);
            }            
        }

        [HttpGet]
        public async Task<Transaction?> GetById(int id)
        {
            return await _transactionService.GetById(id);
        }
    }
}
