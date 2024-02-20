using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using WSClient.UserWS;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private IConfiguration _configuration;
        private UserServicesClient userServicesClient = new UserServicesClient();
        public AuthController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> CheckCredentials([FromBody] UserCredentials credentials)
        {
            CheckCredentialsResult checkCredentialsResult = await userServicesClient.CheckCredentialsAsync(credentials);
            if (!checkCredentialsResult.IsValidUser) return BadRequest("User is not valid");
            var token = await GenerateToken(credentials.email);
            var tokenObject = JsonConvert.DeserializeObject<dynamic>(token);
            var jsonContent = JsonConvert.SerializeObject(new { userId = checkCredentialsResult.UserId, token = tokenObject });

            return Ok(jsonContent);
        }

        private async Task<string> GenerateToken(string parameter)
        {
            HttpClient client = new HttpClient();
            var requestData = new { UserName = parameter };
            var jsonContent = JsonConvert.SerializeObject(requestData);
            var stringContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var url = _configuration.GetValue<string>("ApplicationSettings:SecurityEndPoint");
            HttpResponseMessage response = await client.PostAsync(url, stringContent);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            
            return response.StatusCode.ToString();
        }
    }
}
