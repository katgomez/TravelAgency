using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSClient.ReservationWS;
using WSClient.UserWS;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IConfiguration _configuration;
        private UserServicesClient userServicesClient = new UserServicesClient();
        public UsersController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var user = userServicesClient.GetUsersAsync();
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("{userEmail}")]
        public ActionResult<IEnumerable<User>> GetUser(string userEmail)
        {
            var user = userServicesClient.GetUserByEmailAsync(userEmail);
            if (user == null) return NotFound();
            return Ok(user);
        }


        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {
            var createdUser = userServicesClient.CreateUserAsync(user);
            if (createdUser == null) return StatusCode(500, "Failed to create user");
            return CreatedAtAction(nameof(createdUser), new { id = user.Id }, createdUser);
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
