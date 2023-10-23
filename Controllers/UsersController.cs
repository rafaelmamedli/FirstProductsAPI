using FirstProductsAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FirstProductsAPI.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace FirstProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersConroller: ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UsersConroller(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(UserDTO model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var user = new AppUser
            {
                UserName = model.UserName ,
                Email = model.Email,
                FullName = model.FullName,
                DateAdded = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if(result.Succeeded)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Errors);

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);


            if (user == null)
            {
                return BadRequest(new {message = "email is wrong"});
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password,false);

            if (result.Succeeded)
            {
                return Ok(new { token = GenerateJWT(user) });
            }

            return Unauthorized();

        }

        private object GenerateJWT(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes( _configuration.GetSection("AppSettings:Secret").Value ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor {
                 
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName ?? ""),

                }
                
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token = tokenHandler.CreateToken(tokenDescriptor);



        }
    }
}