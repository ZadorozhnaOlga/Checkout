using System.ComponentModel.DataAnnotations;

namespace Checkout.Db.Models
{
    public class CardDetails
    {
        [Key]
        public int CardDetailsId { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string Cvv { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string ExpiryDay { get; set; } = string.Empty;
        public string ExpiryMonth { get; set; } = string.Empty;
        public string ExpiryYear { get; set; } = string.Empty;
    }
}
