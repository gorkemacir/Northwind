using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Northwind.Entity.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class TokenManager
    {
        IConfiguration configuration;

        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateAccessToken(DtoLoginUser user)
        {
            //claim
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserCode),
                new Claim(JwtRegisteredClaimNames.Jti, user.UserId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            //claim roller
            var claimsRoleList = new List<Claim>
            {
                new Claim("role","Admin"),
                //new Claim("role2","Admin2")
            };

            //security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            //şifrelenmiş kimlik oluşturmak
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //token ayarları
            var token = new JwtSecurityToken
            (
                issuer : configuration["Tokens:Issuer"],//token dağıtıcı url,
                audience : configuration["Tokens:Issuer"],//erişilebilecek api'ler,
                expires : DateTime.Now.AddMinutes(1440),//token süresini 5 dk'ya ayarlıyor, ömrü 5 dk
                notBefore : DateTime.Now,//token üretildikten ne kdar aman sonra devreye girsin
                signingCredentials: cred,//kimlik verdik
                claims : claimsIdentity.Claims//claims'leri verdik
            );

            //token oluşturma sınıfı ile örnek alıp üretmek
            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        }
    }
}
