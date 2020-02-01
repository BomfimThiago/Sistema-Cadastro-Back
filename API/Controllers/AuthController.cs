using API.ViewModels.User;
using Domain.Domain.Auth;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserViewModelEntrada user)
        {
            //valide request
            user.Username = user.Username.ToLower();

            if (await _repo.UserExists(user.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = user.Username
            };

            var createdUser = await _repo.Register(userToCreate, user.Password);

            return Ok(createdUser);
        }
    }
}
