using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using CENA_FOODIE_API.Entities;
using CENA_FOODIE_API.Helpers;
using CENA_FOODIE_API.Model;
using CENA_FOODIE_API.Model.Response;
using CENA_FOODIE_API.Services;
using Newtonsoft.Json.Linq;

namespace CENA_FOODIE_API.Controllers
{
    [Authorize]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;

        public LoginController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        //[AllowAnonymous]
        //[HttpPost("api/authenticate")]
        //public IActionResult Authenticate([FromBody] AuthenticateModel model)
        //{
        //    var user = _userService.Authenticate(model.Username, model.Password);
        //    if (user == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.user_id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    // return basic user info (without password) and token to store client side
        //    return Ok(new
        //    {
        //        Id = user.user_id,
        //        Username = user.user_name,
        //        FullName = user.full_name,
        //        Token = tokenString
        //    });
        //}

        [AllowAnonymous]
        [HttpPost("api/dang-ky")]
        public IActionResult Create([FromBody] User user)
        {
            var response = _userService.Create(user, user.password);
            if (response.success)
                return Ok(response);
            else
                return BadRequest(response);

        }
        [AllowAnonymous]      
        [HttpPost("api/dang-nhap")]
        public IActionResult Login([FromBody] AuthenticateModel model, bool isBusiness)
        {
            var response = new ResponseSingle();
            model.User_name = model.User_name.ToLower();
            var userResponse = _userService.Login(model.User_name, model.Password, isBusiness);
            if (!userResponse.success)
                return BadRequest(userResponse);
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userResponse.data.USER_NAME.ToString()),
                        new Claim(ClaimTypes.Role, userResponse.data.USER_ROLE.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(8),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                User user = new User { user_name = userResponse.data.USER_NAME };
                var refreshToken = _userService.GenerateRefreshToken(user);

                var data = new 
                {
                    token = tokenString,
                    user_role = userResponse.data.USER_ROLE.ToString(),
                    user_id = userResponse.data.USER_ID.ToString(),
                    user_name = userResponse.data.USER_NAME.ToString(),
                    org_id = !isBusiness ? userResponse.data.ORG_ID.ToString() : userResponse.data.MST.ToString(),
                    full_name = userResponse.data.FULL_NAME,
                    refresh_token = refreshToken
                };

                response.success = true;
                response.data = data;
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("api/cap-lai-token")]
        public IActionResult GetNewToken([FromBody] RefreshRequestModel request)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];
            string s = accessToken.ToString().Substring(7);
            var access_token = new JwtSecurityTokenHandler().ReadJwtToken(s);
            var username = access_token.Claims.First(claim => claim.Type == "unique_name").Value;

            var response = new ResponseSingle();
            var userResponse = _userService.GetInfor(username, request.isBusiness);
            if (!userResponse.success)
            {
                response.SetError("1 - Không tồn tại username này");
                return BadRequest(response);
            }
            if (userResponse.data.refresh_token.ToString() != request.refresh_token)
            {
                response.SetError("2 - Token không đúng");
                return BadRequest(response);
            }
            if (DateTime.Parse(userResponse.data.exp_date.ToString()) < DateTime.Now)
            {
                response.SetError("3 - Token đã hết hạn");
                return BadRequest(response);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, userResponse.data.user_name.ToString()),
                        new Claim(ClaimTypes.Role, userResponse.data.user_role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var refreshToken = _userService.GenerateRefreshToken(userResponse.data);

            var data = new
            {
                token = tokenString,
                user_role = userResponse.data.user_role.ToString(),
                user_id = userResponse.data.user_id.ToString(),
                user_name = userResponse.data.user_name.ToString(),
                org_id = !request.isBusiness ? userResponse.data.org_id.ToString() : userResponse.data.mst.ToString(),
                full_name = userResponse.data.full_name,
                refresh_token = refreshToken
            };

            response.success = true;
            response.data = data;
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("api/thu-hoi-token")]
        public IActionResult RevokeToken()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];
            string s = accessToken.ToString().Substring(7);
            var access_token = new JwtSecurityTokenHandler().ReadJwtToken(s);
            var username = access_token.Claims.First(claim => claim.Type == "unique_name").Value;

            var response = new ResponseExecute();
            response = _userService.RevokeToken(username);
            return Ok(response);
        }

        [HttpPost("api/xac-nhan")]
        public IActionResult Approve(string username)
        {
            username = username.ToLower();
            var response = _userService.Approve(username);
            if (response.success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("api/tai-khoan/{username}")]
        public IActionResult GetInfor(string username, bool isBusiness)
        {
            var response = _userService.GetInfor(username, isBusiness);
            if (response != null)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("api/tai-khoan/{username}")]
        public IActionResult EditInfor(string username, bool isBusiness, [FromBody] User user)
        {
            var response = _userService.UpdateInfor(username, isBusiness, user);
            if (response.id == 1)
                return Ok(response);
            else
                return BadRequest(response);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
