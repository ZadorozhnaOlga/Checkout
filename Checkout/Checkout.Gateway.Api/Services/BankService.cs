using Checkout.Gateway.Api.Interfaces;
using Checkout.Gateway.Api.Models;
using System.Text.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Checkout.Db.Models;

namespace Checkout.Gateway.Api.Services
{
    public class BankService : IBankService
    {
        private const string URL = "https://localhost:7251/";
        private readonly IHttpClientFactory _httpClientFactory;

        public BankService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
            
        public async Task<TransactionStatus> HandleTransaction(PaymentRequest paymentRequest)
        {         
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(URL);
            //var httpResponseMessage = await httpClient.PostAsync(httpRequestMessage);

            var json = new StringContent(JsonSerializer.Serialize(paymentRequest), Encoding.UTF8, Application.Json);

            var httpResponseMessage = await httpClient.PostAsync("/api/ProcessTransaction", json);

            return httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK 
                ? TransactionStatus.Ok 
                : TransactionStatus.Failed;
        }
    }
}
