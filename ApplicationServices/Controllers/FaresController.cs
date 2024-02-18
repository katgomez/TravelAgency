using ApplicationServices.Models.Fares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaresController : ControllerBase
    {

        private IConfiguration _configuration;

        public FaresController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<FareResultDto>> GetFares()
        {   
            return Ok(new FareResultDto());
        }
    }
}
