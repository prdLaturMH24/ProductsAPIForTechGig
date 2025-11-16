using Microsoft.AspNetCore.Mvc;

namespace ProductsAPIForTechGig.Controllers
{
    [Route("/")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductAsync()
        {
            return Ok("Welocme .Net Core API.");
        }

    }
}
