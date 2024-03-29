﻿using Microsoft.AspNetCore.Mvc;
using WSClient.FlightReservation;
using WSClient.UserWS;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TokenValidation]
    public class UsersController : ControllerBase
    {
        private IConfiguration _configuration;
        private UserServicesClient userServicesClient;
        public UsersController(IConfiguration configuration)
        {
            this._configuration = configuration;

            userServicesClient = new UserServicesClient(UserServicesClient.
            EndpointConfiguration.BasicHttpBinding_IUserServices, _configuration.GetValue<string>("ApplicationSettings:AppDataUserServiceEndPoint"));
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var user = userServicesClient.GetUsersAsync();
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<User>> GetUserAsync(int userId)
        {
            var user = await userServicesClient.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{userEmail}")]
        public async Task<ActionResult<User>> GetUser(string userEmail)
        {
            var user = await userServicesClient.GetUserByEmailAsync(userEmail);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("statistics")]
        public async Task<ActionResult<long>> GetUsersStatistics()
        {
            long response = await userServicesClient.CountUsersAsync();


            return Ok(response);


        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            int createdUser = await userServicesClient.CreateUserAsync(user);
            if (createdUser == null) return StatusCode(500, "Failed to create user");
            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] User userUpdated)
        {
            if (id != userUpdated.Id) return NotFound();
            else
            {
                var updated = userServicesClient.UpdateUserAsync(userUpdated);
                if (updated == null) return NotFound();
                return NoContent();
            }

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var deleted = userServicesClient.DeleteUserAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
