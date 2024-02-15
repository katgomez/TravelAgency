using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IConfiguration _configuration;
        public FlightsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
    }
}
