using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Dtos.Dto;
using Model.Entitys;

namespace ErpManagerSystem.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAcUserInfoServices _acUserInfoServices;
        private readonly IConfiguration _configuration;

        public LoginController(IAcUserInfoServices acUserInfoServices, IConfiguration configuration)
        {
            _acUserInfoServices = acUserInfoServices;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult<ActionResult<MessageModel<string>>>> Login(LoginDto loginDto)
        {
            MessageModel<string> res = new MessageModel<string>();
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            AcUserInfo user = await _acUserInfoServices.GetEntitys(a => a.Pwd == loginDto.Pwd && a.Account == loginDto.Account).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound(StyleCode.NotFound(res));
            }
            string token = jwtHandler.WriteToken(new JwtSecurityToken
            (issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims: new Claim[]
                {
                    new Claim("id",user.Id.ToString()),
                },
                expires: DateTime.Now.AddDays(7),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SigningKey"])), SecurityAlgorithms.HmacSha256)
            ));
            res.Data = "Bearer " + token;
            return Ok(res);
        }
    }
}