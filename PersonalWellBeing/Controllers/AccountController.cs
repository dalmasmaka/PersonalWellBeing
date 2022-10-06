using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalWellBeing.DTO;
using PersonalWellBeing.Models;
using PersonalWellBeing.Services;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PersonalWellBeing.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
      
        public AccountController(UserManager<User> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
         
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>>Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Username);
            if(user==null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password))
                return Unauthorized();
            return new UserDTO
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult>Register(RegisterDTO registerDTO)
        {
            var user = new User { UserName = registerDTO.Username, Email = registerDTO.Email };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
            }
            await _userManager.AddToRoleAsync(user, "Member");
            return StatusCode(201);        
        }
        [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return new UserDTO
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };
        }
        
        [HttpGet("allUsers")]
        public async Task<List<UserDTO>> getUsers()
        {
            var users = _userManager.Users.ToList();
            var roles = new List<string>();

            var UserViewModel = new List<UserDTO>();
            foreach (var user in users)
            {
                roles = _userManager.GetRolesAsync(user).Result.ToList();
                UserViewModel.Add(new UserDTO { Email = user.Email, Name = user.UserName, Role = roles.FirstOrDefault() });

            }
            return UserViewModel;
        }
    }
}
