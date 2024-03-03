using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Dtos.Account;
using WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> usermanager, ITokenService tokenService,SignInManager<AppUser> appuser)
        {
            _usermanager = usermanager;
            _tokenService = tokenService;
            _signInManager = appuser;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto rg)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var appuser = new AppUser
                {
                    UserName = rg.Username,
                    Email = rg.EmailAddress
                };
                var createUser = await _usermanager.CreateAsync(appuser, rg.Password);
                if (createUser.Succeeded)
                {
                    var roleResult = await _usermanager.AddToRoleAsync(appuser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            UserName = appuser.UserName,
                            Token = _tokenService.CreateToken(appuser)
                        });
                    }
                    else return StatusCode(500, roleResult.Errors);
                }
                else return StatusCode(500,createUser.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _usermanager.Users.FirstOrDefaultAsync(x=>x.UserName == loginDto.UserName);
            if (user == null) return Unauthorized("invalid username");
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if (!result.Succeeded) return Unauthorized("username of password is incorrect");

            return Ok(new NewUserDto
            {
                UserName = loginDto.UserName,
                Token = _tokenService.CreateToken(user)
            });
        }
    }
}
