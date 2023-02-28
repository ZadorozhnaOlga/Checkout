using System.ComponentModel.DataAnnotations;

namespace Checkout.Gateway.Api.Models
{
    public class PaymentRequest
    {
        [Required]
        public CardDetails CardDetails { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public float Amount { get; set; }
    }
    
}
