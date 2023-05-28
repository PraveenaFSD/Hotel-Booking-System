using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Interfaces;
using UserAPI.Models.DTO;
using UserAPI.Models;
using UserAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        private readonly IRepo<string, User> _repo;

        public UserController(UserService userService, IRepo<string, User> repo)
        {
            _service = userService;
            _repo = repo;
        }
        [HttpPost("Register User")]
        [ProducesResponseType(typeof(ICollection<UserDTO>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> Register([FromBody] UserRegisterDTO userDTO)
        {
            var user = _service.Register(userDTO);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("Cannot Register user");

        }
        [HttpPost("Login User")]
        [ProducesResponseType(typeof(ICollection<UserDTO>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> Login([FromBody] UserDTO userDTO)
        {
            var user = _service.Login(userDTO);
            if (user != null)
            {
                return Created("Home", user);
            }
            return BadRequest("Cannot Login user. Password or username may be incorrect");

        }
        [Authorize]
        [HttpPost("UpdateUserPassword")]
        [ProducesResponseType(typeof(ICollection<UserDTO>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> UpdatePassword([FromBody] UserDTO userDTO)
        {
            var user = _repo.Update(userDTO);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("Cannot Update Password");
        }
    }
    //[HttpGet("GetAllUser")]
    //[ProducesResponseType(typeof(ICollection<UserDTO>), 200)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public ActionResult<UserDTO> GetAllUser([FromBody] UserDTO userDTO)
    //{
    //    var user = _service.GetAllUser(userDTO);
    //    if (user != null)
    //    {
    //        return Created("Home", user);
    //    }
    //    return BadRequest("Cannot Login user. Password or username may be incorrect");

    //}
}
