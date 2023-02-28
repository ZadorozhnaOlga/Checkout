using Microsoft.AspNetCore.Mvc;

namespace Checkout.BankSimulator.Controllers
{
    [ApiController]
    [Route("[controller]")]

    
    public class TransactionController : ControllerBase
    {


        [HttpPost]
        public IActionResult ProcessTransaction()
        {
            return Ok();
        }
    }
}