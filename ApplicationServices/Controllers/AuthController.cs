﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using RestSharp;
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
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:SecurityEndPoint"));
            var request = new RestRequest("", Method.Post);
            request.AddBody(credentials.email);
            var result = client.ExecuteAsync<dynamic>(request).Result.Data;
            return Ok();
        }
    }
}
