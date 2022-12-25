using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPICRMSkillProfi.Models
{
    public class TokenGenerator
    {
        private ClaimsIdentity _claimsIdentity;
        private JwtSecurityToken _jwt;
        private DateTime _nowDataTime;
        private List<Claim> _claims;
        private string _encodedJwt;
        public object Token(User _currentUser)
        {
            _nowDataTime = DateTime.UtcNow;

             _claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, _currentUser.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, _currentUser.Role)
                };

            _claimsIdentity = new ClaimsIdentity(_claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                                                                   ClaimsIdentity.DefaultRoleClaimType);

            // создаем JWT-токен
            _jwt = new JwtSecurityToken(issuer: Option.ISSUER,
                                        audience: Option.AUDIENCE,
                                        notBefore: _nowDataTime,
                                        claims: _claimsIdentity.Claims,
                                        expires: _nowDataTime.Add(TimeSpan.FromMinutes(Option.LIFETIME)),
                                        signingCredentials: new SigningCredentials(Option.GetSymmetricSecurityKey(),
                                        SecurityAlgorithms.HmacSha256));

            _encodedJwt = new JwtSecurityTokenHandler().WriteToken(_jwt);

            object _response = new { access_token = _encodedJwt, username = _claimsIdentity.Name };

            return _response;
        }
    }
}
