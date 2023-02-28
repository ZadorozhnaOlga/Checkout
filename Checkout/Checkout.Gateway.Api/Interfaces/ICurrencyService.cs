using Checkout.Db.Models;

namespace Checkout.Gateway.Api.Interfaces
{
    public interface ICurrencyService
    {
        Task<Currency?> GetCurrency(string name);
    }
}
