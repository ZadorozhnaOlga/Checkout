using System.ComponentModel.DataAnnotations;

namespace Checkout.Gateway.Api.Models
{
    public class CardDetails
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string Cvv { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public string ExpiryDay { get; set; } 

        [Required]
        public string ExpiryMonth { get; set; }

        [Required]
        public string ExpiryYear { get; set; }
    }
}
