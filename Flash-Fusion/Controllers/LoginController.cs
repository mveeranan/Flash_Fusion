using Azure;
using Flash_Fusion.Application._System._Login.Dto;
using Flash_Fusion.Application._System.Repositories._Login;
using Flash_Fusion.EntityFrameWorkCore._System.Data;
using JWT_Authentication_Web_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Authentication_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
        {

        private readonly ILoginRepository _loginRepository;
        ResponseDto res = new ResponseDto();
        private readonly IConfiguration _config;
        public LoginController(ILoginRepository loginRepository, IConfiguration configuration)
            {
            _loginRepository = loginRepository;
            _config = configuration;
            }
        [HttpPost]
        public async Task<IActionResult> Login (LoginDto model)
            {
            try
                {
                var data = await _loginRepository.Login(model);
                if (data.Count == 0)
                    {
                    res.StatusCode = 404;
                    res.Message = "Invalid Credential";
                    return NotFound(res);
                    }
                else
                    {
                    var Claims = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim("Email", data[0].Email),
                        new Claim("UserId",data[0].Id.ToString()),
                        new Claim("Name",data[0].Name),
                        };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        Claims,
                        expires: DateTime.UtcNow.AddMinutes(2),
                        signingCredentials: signIn
                        );
                    string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.Result = tokenValue;
                    return Ok(res);
                    }
                }
            catch(Exception ex) 
                {
                //res.StatusCode = 500;
                //res.Message = "Internal Server Error";
                //return Ok(res);
                return Ok(ex);
                }
            }


        }
    }
