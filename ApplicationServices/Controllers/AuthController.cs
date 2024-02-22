using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using WSClient.ReservationWS;
using WSClient.UserWS;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        private UserServicesClient userServicesClient;
        public AuthController(IConfiguration configuration)
        {
            this._configuration = configuration;
            userServicesClient = new UserServicesClient(UserServicesClient.
            EndpointConfiguration.BasicHttpBinding_IUserServices, _configuration.GetValue<string>("ApplicationSettings:AppDataUserServiceEndPoint"));
        }
        [HttpPost]
        public async Task<IActionResult> CheckCredentials([FromBody] UserCredentials credentials)
        {
            CheckCredentialsResult checkCredentialsResult = await userServicesClient.CheckCredentialsAsync(credentials);
            if (!checkCredentialsResult.IsValidUser) return BadRequest("User is not valid");
            var token = GenerateToken(credentials.email);
            if (token != null)
            {
                var jsonContent = JsonConvert.SerializeObject(new { userId = checkCredentialsResult.UserId, token = token });
                return Ok(jsonContent);
            }
            return Unauthorized();
        }

        private String GenerateToken(string parameter)
        {

            var options = new RestClientOptions(
              _configuration.GetValue<string>("ApplicationSettings:SecurityEndPoint"));

            options.RemoteCertificateValidationCallback =
                                 (sender, certificate, chain, sslPolicyErrors) => true;


            RestClient client = new RestClient(options);
            var request = new RestRequest("", Method.Post);
            var requestData = new { userName = parameter };

            request.AddBody(requestData);

            var response = client.ExecuteAsync(request).Result;

            if (response.IsSuccessStatusCode) {

                var response2 = JsonConvert.DeserializeAnonymousType(response.Content, new { token = "" });
                return response2.token;
            }
            return null;
        }

        [HttpPost("user")]
        public async Task<ActionResult> CreateAuthUser([FromBody] User user)
        {
            int createdUser = await userServicesClient.CreateUserAsync(user);
            if (createdUser == null) return StatusCode(500, "Failed to create user");
            return Ok(createdUser);
        }
    }
}
