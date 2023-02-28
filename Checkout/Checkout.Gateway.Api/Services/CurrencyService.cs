using Checkout.Db.Models;
using Checkout.Db.Repository;
using Checkout.Gateway.Api.Interfaces;

namespace Checkout.Gateway.Api.Services
{
    public class CurrencyService : ICurrencyService
    {

        public ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<Currency?> GetCurrency(string name)
        {
            // return await  _currencyRepository.Find(x => x.CurrencyName == name); - TODO implement
            return await Task.FromResult(new Currency());
        }
    }
}
