using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using class_management_web_api.src.Contexts;
using class_management_web_api.src.DTO.Authentication;
using class_management_web_api.src.Requests.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace class_management_web_api.src.Repositories.Authentication
{
    public class AuthenticationPostRepository : IAuthenticationPostRepository
    {
        private ApplicationDbContext _context;
        public AuthenticationPostRepository( ApplicationDbContext context){
            _context = context;
        }
        public async Task<AuthenticationPostDTO> Authenticate (AuthenticationPostRequest request){
            var record = await _context.Users.FirstOrDefaultAsync(r => r.Email == request.Email);
            var tokenHandler = new JwtSecurityTokenHandler();
            var salt = Encoding.ASCII.GetBytes(record.Salt);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, record.Name),
                    new Claim(ClaimTypes.Email, record.Email),
                }),
                Expires = DateTime.UtcNow.AddDays(3)
            };
            //TODO método de desencriptar a senha usando o salt para validar se o usuário está com as credenciais validas
            return new AuthenticationPostDTO{};
        }
    }
}