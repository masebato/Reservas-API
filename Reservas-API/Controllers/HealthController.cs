using Microsoft.AspNetCore.Mvc;
using Reservas_API.Controllers.V1;

namespace Reservas_API.Controllers
{
    public class HealthController : MainController
    {
        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {
            return Ok("OK");
        }
    }
}
