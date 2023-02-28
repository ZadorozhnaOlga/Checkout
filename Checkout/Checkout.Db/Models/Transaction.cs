using System.ComponentModel.DataAnnotations;

namespace Checkout.Db.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public float Amount { get; set; }
        public TransactionStatus Status { get; set; }
        public int CurrencyId { get; set; }
        public int CardDetailsId { get; set; }
        public CardDetails CardDetails { get; set; } = new CardDetails();
        public Currency Currency { get; set; } = new Currency();
    }
}
