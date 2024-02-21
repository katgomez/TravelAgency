using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WS.Unit10.Task2.Security.Utils;

namespace WS.Unit10.Task2.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        // GET: api/Tokens/ASHYT656YT56
        [HttpGet("{token}")]
        public ActionResult<String> Get([FromRoute] string token)
        {
            try
            {
                var securityToken = JsonConvert.DeserializeObject<dynamic>(
                                                             AESManager.Decrypt(token));
                if (securityToken == null)
                {
                    return NotFound();
                }
                else if (DateTime.Parse(
                    securityToken.ExpirationDate.ToString()) > DateTime.Now)
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception) { return BadRequest(); }
        }


        // POST: api/Tokens
        [HttpPost]
        public IActionResult Post([FromBody] dynamic tokenRequest)
        {
            try
            {
                var userName = JsonConvert.DeserializeObject<dynamic>(
                                          tokenRequest.ToString()).UserName.ToString();
                var token = AESManager.Encrypt(JsonConvert.SerializeObject(
                        new { UserName = userName, ExpirationDate = DateTime.Now.AddDays(30) }));
                return CreatedAtAction(
                                       "Get", new { token = token }, new { Token = token });
            }
            catch (Exception) { return BadRequest(); }
        }

    }
}
