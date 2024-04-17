using Crud.DTO.Security;
using Crud.Handler;
using Crud.Interface;
using Crud.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly JWTSettings _jwt;
        private readonly ISecurity _security;
        public SecurityController(IOptions<JWTSettings> jwt,ISecurity security) {
            this._jwt = jwt.Value;
            this._security = security;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            tblUsers user = await _security.Login(request);
            if (user == null)
            {
                return Unauthorized("Invaild User Details...");
            }
            return GenerateToken(user,string.Empty);
        }

        [HttpPost("Refresh-Token")]
        public IActionResult Refresh([FromBody] LoginResponseDTO request) => GenerateToken(null, request.Token);

        private IActionResult GenerateToken(tblUsers? user,string token)
        {
            #region old Token generation
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var securityKey = Encoding.UTF8.GetBytes(_jwt.KEY);
            //var tokenDiscriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.NameIdentifier, user.Usr_Id.ToString()),
            //        new Claim(ClaimTypes.Name, user.Usr_Name),
            //        new Claim(ClaimTypes.Role,"Student"),
            //        new Claim(ClaimTypes.Email, user.Usr_Email)
            //    }),
            //    Expires = DateTime.Now.AddMinutes(_jwt.Expire),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256)
            //};

            //var token = tokenHandler.CreateToken(tokenDiscriptor);
            //string _Result = tokenHandler.WriteToken(token);
            //return Ok(_Result);
            #endregion

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.KEY));

            var tokenOptions = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: !string.IsNullOrEmpty(token) ? GetClaimsPrincipal(token).Claims : new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user!.Usr_Id.ToString()),
                    new Claim(ClaimTypes.Name, user!.Usr_Name),
                    new Claim(ClaimTypes.Role,user!.Usr_Role)
                },
                expires: DateTime.Now.AddMinutes(_jwt.Expire),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );
            LoginResponseDTO response = new LoginResponseDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                RefreshToken = GetRefreshToken(),
                Expiry = DateTime.Now.AddMinutes(_jwt.RefreshTokenExpire)
            };
            return Ok(response);
        }

        private string GetRefreshToken()
        {
            var randomnumber = new byte[64];
            var rng=RandomNumberGenerator.Create();
            rng.GetBytes(randomnumber);
            return Convert.ToBase64String(randomnumber);
        }

        private ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            var parameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.KEY)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
            var tokenHandler= new JwtSecurityTokenHandler();
            var principal=tokenHandler.ValidateToken(token, parameters, out SecurityToken claims);
            return principal;
        }
    }
}
