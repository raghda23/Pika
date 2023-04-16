using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Pikia.APIs.DTOs;
using Pikia.APIs.Errors;
using Pikia.Core.Entities.Indentity;
using Pikia.Core.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pikia.APIs.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;

        public AccountsController(UserManager<AppUser> _userManager , SignInManager<AppUser> _signInManager , ITokenService _tokenService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            tokenService = _tokenService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new APIsResponse(401));

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (!result.Succeeded) return Unauthorized(new APIsResponse(401));

              return Ok(new UserDto
              {
                  DisplayName = user.DisplayName,
                  Email = user.Email,
                  Token = await tokenService.CreateToken(user , userManager)

              });
        }


        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExist(registerDto.Email).Result.Value)
                return BadRequest(new ApiValidationResponse() { Errors = new [] {"This Email is already exist!"}});
            var user = new AppUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
               PhoneNumber = registerDto.PhoneNumber,
               UserName = registerDto.Email.Split("@")[0],
               Country = registerDto.Country,
               City = registerDto.City,
               Street = registerDto.Street
            };
            var result = await userManager.CreateAsync(user , registerDto.Password);
            if (!result.Succeeded) return BadRequest(new APIsResponse(400));

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await tokenService.CreateToken(user, userManager)
            });
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email =User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName
                ,
                Email = user.Email,
                Token =await tokenService.CreateToken(user , userManager)
            }) ;
        }


        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExist(string email)
        {
            return await userManager.FindByEmailAsync(email) != null;
        }
    }

}
