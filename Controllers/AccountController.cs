using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapp1.DTOs;
using webapp1.Models;
using webapp1.Services.Interfaces;

namespace webapp1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {

        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(dto.Email);

            if (appUser == null)
            {
                return BadRequest("User not found");
            }

            bool result = await _userManager.CheckPasswordAsync(appUser, dto.Password);

            if (result)
            {
                var token = await _tokenService.CreateToken(appUser);
                return Ok(new { token });
            }

            return BadRequest("User not authenticated");


        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(dto.Email);

            if (appUser != null)
                return BadRequest(new RegResult { Text = "email already exist", Status = 200 });


            IdentityResult result = await _userManager.CreateAsync(new AppUser { Email = dto.Email, UserName = dto.Username }, dto.Password);


            if (result.Succeeded)
                return Ok("created successfully");

            return BadRequest(result.Errors);
        }

        public class RegResult
        {
            public int Status { get; set; }
            public string Text { get; set; }
        }
    }
}