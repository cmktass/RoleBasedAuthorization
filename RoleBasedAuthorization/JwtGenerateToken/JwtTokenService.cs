using Microsoft.IdentityModel.Tokens;
using RoleBasedAuthorization.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAuthorization.WebApi.JwtGenerateToken
{
    public class JwtTokenService
    {
        public string GenerateJwtToken(User user, List<Role> roles)
        {
            SymmetricSecurityKey symmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PASSWORD"));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurity,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer:"localhost://",audience:"localhost://",notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(4),signingCredentials: signingCredentials,claims: CreateClaims(user,roles));
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }
        private List<Claim> CreateClaims(User user, List<Role> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            if(roles.Count > 0)
            {
                foreach (var item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.Name));
                }
            }
            return claims;
        }
    }
}
