using Checkout.Db.Models;
using Checkout.Gateway.Api.Models;

namespace Checkout.Gateway.Api.Interfaces
{
    public interface IBankService
    {
        Task<TransactionStatus> HandleTransaction(PaymentRequest paymentRequest);
    }
}
