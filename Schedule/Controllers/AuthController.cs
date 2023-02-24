using Microsoft.AspNetCore.Mvc;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        // TODO: create DTO for staff\admin registration purposes
        [HttpPost("register")]
        public IActionResult Register() { return Ok(); }

        // TODO: create DTO for login creds & token creation
        [HttpPost("login/mobile")]
        public IActionResult MobileLogin() { return Ok(); }

        [HttpPost("login/web")]
        public IActionResult WebLogin() { return Ok(); }
        // TODO: token blacklisting
        [HttpPost("logout")]
        public IActionResult Logout() { return Ok(); }
    }
}
