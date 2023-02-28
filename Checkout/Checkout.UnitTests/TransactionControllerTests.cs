using Checkout.Db.Models;
using Checkout.Gateway.Api.Interfaces;
using Checkout.Gateway.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Checkout.UnitTests
{
    [TestFixture]
    public class TransactionControllerTests
    {
        private Mock<ICurrencyService> _currencyService = default!;
        private Mock<ITransactionService> _transactionService = default!;
        private Mock<IBankService> _bankService = default!;      


        [SetUp] 
        public void Init() {
            _currencyService = new Mock<ICurrencyService>();
            _transactionService = new Mock<ITransactionService>();
            _bankService = new Mock<IBankService>();
        }

        [Test]
        public async Task GetById()
        {
            _transactionService.Setup(service => service.GetById(It.IsAny<int>()))
                .Returns((int id) => 
                { 
                    return Task.FromResult(new Transaction { TransactionId = id }); 
                }) ;

            var controller = new Gateway.Api.Controllers.TransactionController(
                _currencyService.Object, 
                _transactionService.Object,
                _bankService.Object);

            var result = await controller.GetById(10);

            Assert.AreEqual(10, result.TransactionId);
        }

        [Test]
        public async Task ProcessTransaction_InvalidModelState()
        {
            var controller = new Gateway.Api.Controllers.TransactionController(
                _currencyService.Object,
                _transactionService.Object,
                _bankService.Object);

            controller.ModelState.AddModelError("CardDetails", "CardDetails is required");
            var result = await controller.ProcessTransaction(new PaymentRequest()) as BadRequestObjectResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task ProcessTransaction_InvalidCurrency()
        {
            var controller = new Gateway.Api.Controllers.TransactionController(
                _currencyService.Object,
                _transactionService.Object,
                _bankService.Object);

            var result = await controller.ProcessTransaction(new PaymentRequest() { Amount = 10 }) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Invalid Currency", result.Value);
        }

        [Test]
        public async Task ProcessTransaction_InvalidAmount()
        {
            var controller = new Gateway.Api.Controllers.TransactionController(
                _currencyService.Object,
                _transactionService.Object,
                _bankService.Object);

            var result = await controller.ProcessTransaction(new PaymentRequest() { Amount = 0, Currency = "GBP" }) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Amount should be non-negative", result.Value);
        }


        [Test]
        public async Task ProcessTransaction_TransactionFailed()
        {
            _currencyService.Setup(service => service.GetCurrency(It.IsAny<string>()))
                .Returns(Task.FromResult<Currency?>(new Currency()));

            _transactionService.Setup(service => service.SaveTransaction(It.IsAny<Transaction>()))
                .Returns((Transaction transaction) =>
                {
                    transaction.TransactionId = 1;
                    return Task.FromResult(transaction);
                });

            _bankService.Setup(service => service.HandleTransaction(It.IsAny<PaymentRequest>()))
                .Returns(Task.FromResult(TransactionStatus.Failed));

            var controller = new Gateway.Api.Controllers.TransactionController(
                _currencyService.Object,
                _transactionService.Object,
                _bankService.Object);

            var result = await controller.ProcessTransaction(GeneratePaymentRequest()) as BadRequestObjectResult; 

            Assert.IsNotNull(result);
            Assert.AreEqual(TransactionStatus.Failed, (result.Value as Transaction)?.Status);

        }

        [Test]
        public async Task ProcessTransaction_TransactionSucceeded()
        {
            _currencyService.Setup(service => service.GetCurrency(It.IsAny<string>()))
                .Returns(Task.FromResult<Currency?>(new Currency()));

            _transactionService.Setup(service => service.SaveTransaction(It.IsAny<Transaction>()))
                .Returns((Transaction transaction) =>
                {
                    transaction.TransactionId = 1;
                    return Task.FromResult(transaction);
                });

            _bankService.Setup(service => service.HandleTransaction(It.IsAny<PaymentRequest>()))
                .Returns(Task.FromResult(TransactionStatus.Ok));

            var controller = new Gateway.Api.Controllers.TransactionController(
                _currencyService.Object,
                _transactionService.Object,
                _bankService.Object);

            var result = await controller.ProcessTransaction(GeneratePaymentRequest()) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(TransactionStatus.Ok, (result.Value as Transaction)?.Status);

        }


        private PaymentRequest GeneratePaymentRequest() 
        {
            return new PaymentRequest
            {
                Amount = 10,
                Currency = "GBP",
                CardDetails = new Gateway.Api.Models.CardDetails
                {
                    CardNumber = "123456789",
                    Cvv = "123",
                    AccountName = "Olha Zadorozhna",
                    ExpiryDay = "10",
                    ExpiryMonth = "10",
                    ExpiryYear = "2023"
                }
            }; 
        }
    }
}