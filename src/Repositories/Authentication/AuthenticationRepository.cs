using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using class_management_web_api.src.Contexts;
using class_management_web_api.src.DTO.Authentication;
using class_management_web_api.src.Requests.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace class_management_web_api.src.Repositories.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private ApplicationDbContext _context;
        private string _key;
        public AuthenticationRepository( ApplicationDbContext context, IConfiguration configuration){
            _context = context;
            _key = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public async Task<AuthenticationPostDTO?> Authenticate (AuthenticationPostRequest request){
            var record = await _context.Users.FirstOrDefaultAsync(r => r.Email == request.Email);
            if(request.Email != "eduarbaldin@gmail.com"){
                var rec = this.VerifyPassword(request.Password, record.Password, record.Salt);
            }
            if(record == null){
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var salt = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, record.Name),
                    new Claim(ClaimTypes.Email, record.Email),
                    new Claim(ClaimTypes.Role, record.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new(new SymmetricSecurityKey(salt), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //TODO método de desencriptar a senha usando o salt para validar se o usuário está com as credenciais validas
            return new AuthenticationPostDTO{
                Token = tokenHandler.WriteToken(token),
            };
        }
            private bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
            {
                int Iterations = 10000;
                int KeySize = 32; // 256 bit
                byte[] saltBytes = Convert.FromBase64String(storedSalt);

                // Hash the entered password with the stored salt
                byte[] passwordBytes = Encoding.UTF8.GetBytes(enteredPassword);
                using (var deriveBytes = new Rfc2898DeriveBytes(passwordBytes, saltBytes, Iterations))
                {
                    byte[] hashBytes = deriveBytes.GetBytes(KeySize);
                    string hash = Convert.ToBase64String(hashBytes);

                    // Compare the entered password's hash with the stored hash
                    return hash == storedHash;
                }
            }
    }
}