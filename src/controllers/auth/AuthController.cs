using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using controllers.Models;

namespace controllers.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        public AuthController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{userId}")]
        public ActionResult<userDTO> GetUser(Guid userId) {
            try
            {
                var user = _userService.getUser(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("login")]
        public ActionResult<Guid> login([FromBody] userDTO user)
        {
            try
            {
                if (user.email_address == null || user.password == null)
                {
                    throw new Exception("Email and password are required");
                }
                var userId = _userService.login(user);
                return Ok(userId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create")]
        public ActionResult<Guid> create([FromBody] userDTO user)
        {
            try
            {
                

                if (user.email_address == null || user.password == null || user.name == null)
                {
                    throw new Exception("Email and password and name are required");
                }
                var userId = _userService.create(user);
                Console.WriteLine(user.name);
                Console.WriteLine(user.email_address);
                Console.WriteLine(user.password);
                Console.WriteLine(userId);

                return Ok(userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return BadRequest(e.Message);
            }
                
        }

    }
}