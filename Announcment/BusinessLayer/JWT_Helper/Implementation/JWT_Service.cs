using BusinessLayer.DTO.ResponseDTO;
using BusinessLayer.JWT_Helper.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.JWT_Helper.Implementation
{
    public class JWT_Service : IJWT_Service
    {
        private readonly IConfiguration configuration;

        public JWT_Service(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<LoginResponseDTO> CreateToken(string email, List<string> roles)
        {
            var issuer = configuration["Appsettings:ValidIssuer"];
            var audience = configuration["Appsettings:ValidAudience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Appsettings:Secret"]));

            var dateTimeNow = DateTime.Now;
            int expireMinute = int.Parse(configuration["Appsettins:Expire"]);
            var claimList = new List<Claim>
            {
                new Claim("UserEmail",email)
            };
            foreach(var role in roles)
            {
                claimList.Add(new Claim(ClaimTypes.Role, role));
            };
            JwtSecurityToken jwt = new JwtSecurityToken(
                 issuer: configuration["AppSettings:ValidIssuer"],
                 audience: configuration["AppSettings:ValidAudience"],
                 claims: claimList,
                 notBefore: dateTimeNow,
                 expires: dateTimeNow.Add(TimeSpan.FromMinutes(expireMinute)),
                 signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
             );
            return await  Task.FromResult(new LoginResponseDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                ExpireDate =  dateTimeNow.Add(TimeSpan.FromMinutes(expireMinute))
            });
        }
    }
}
