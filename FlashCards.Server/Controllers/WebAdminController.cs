using FlashCards.Server.Models.DTO;
using FlashCards.Server.Models.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static FlashCards.Server.Models.Constants;


namespace FlashCards.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebAdminController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public WebAdminController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration
        )
        {
            _userManager = userManager;
            _roleManager = roleManager; 
            _configuration = configuration;
        }

        //[AllowAnonymous]
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            return Unauthorized();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, Route("register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null)
            {
                // log user already exists
                return Problem();
            }
            else
            {
                IdentityUser newUser = new()
                {
                    Email = request.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.UserName
                };

                var userCreated = await _userManager.CreateAsync(newUser, request.Password);

                if (!userCreated.Succeeded)
                {
                    // log user creation failed
                    return Problem();
                }
                else
                {
                    if (request.IsAdmin)
                    {
                        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                        {
                            await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);
                        }
                    }

                    if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                    }

                    if (await _roleManager.RoleExistsAsync(UserRoles.User))
                    {
                        await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                    }
                }
                return Ok(new ResponseModel<string>() { Data = newUser.UserName, Message = "User registered!", Success = true });
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecuritySettings:JWTKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["SecuritySettings:JWTIssuer"],
                audience: _configuration["SecuritySettings:JWTAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
