using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Services;
using InvoiceManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            TokenService tokenService,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null)
            {
                _logger.LogError("AccountController.Login - Unauthorized.");
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                _logger.LogInformation("AccountController.Login - Login succesful.");

                return new UserDto
                {
                    Username = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }

            _logger.LogError("AccountController.Login - Unauthorized.");
            return Unauthorized();
        }
    }
}
