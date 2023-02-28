using System.ComponentModel.DataAnnotations;

namespace Checkout.Db.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; } = string.Empty;
    }
}
