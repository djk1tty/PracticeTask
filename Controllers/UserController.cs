using FileExchangerAPI.ActionClass.HelperClass;
using FileExchangerAPI.ActionClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileExchangerAPI.Interface;

namespace FileExchangerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;

        public UserController(IUser iUser)
        {
            _IUser = iUser;
        }

        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public List<string> Post(UserCreate user)
        {
            return _IUser.AddUser(user);
        }

        [HttpGet("GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<UserDTO> Get()
        {
            return _IUser.GetUsers();
        }

        [HttpGet("GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<UserDTO> Get(int id)
        {
            return _IUser.GetUser(id);
        }
        [HttpDelete("DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public List<string> Delete(int id)
        {
            return _IUser.DeleteUser(id);
        }

        [HttpPatch("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<string> Patch(int id, UpdateUserDTO user)
        {
            return _IUser.UpdateUser(id, user);
        }
    }
}
