using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using class_management_web_api.src.Contexts;
using class_management_web_api.src.DTO;
using class_management_web_api.src.DTO.Register;
using class_management_web_api.src.Entities;
using class_management_web_api.src.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace class_management_web_api.src.Repositories.Register
{
    public class RegisterRepository : IRegisterRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public RegisterRepository(ApplicationDbContext context
                             , IMapper mapper
                             , IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
        }
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit
        private const int Iterations = 10000;

        private (string hash, string salt) HashPassword(string password)
        {
            // Generate a salt
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            // Hash the password with the salt
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            using (var deriveBytes = new Rfc2898DeriveBytes(passwordBytes, saltBytes, Iterations))
            {
                byte[] hashBytes = deriveBytes.GetBytes(KeySize);
                string hash = Convert.ToBase64String(hashBytes);
                return (hash, salt);
            }
        }
        public async Task<GenericResponse> ActivateRegister(Guid id)
        {
            
            try
            {
                var record = await _context.Registers.FirstOrDefaultAsync(r => r.RegisterId == id);
                //alterar variavel abaixo
                var teste = this.HashPassword(record.Password);
                var user = new Entities.User(){
                    Id = Guid.NewGuid(),
                    Name = record.Name,
                    Email = record.Email,
                    CPF = record.CPF,
                    Salt = teste.salt,
                    Password = teste.hash,
                    Role = Roles.Manager
                };
                await _context.Users.AddAsync(user);
                if(record.Role.ToString() == "Manager"){
                var manager = new Entities.Manager(){
                    ManagerId = user.Id,
                    Name = record.Name,
                    Email = record.Email,
                    CPF = record.CPF,
                    Password = teste.hash,
                };
                await _context.Managers.AddAsync(manager);
                }
                if(record.Role.ToString() == "Teacher"){
                var teacher = new Entities.Teacher(){
                    TeacherId = user.Id,
                    Name = record.Name,
                    Email = record.Email,
                    CPF = record.CPF,
                    Password = teste.hash,
                };
                await _context.AddAsync(teacher);
                }
                record.IsActive = 1;
                _context.Registers.Update(record);
                await _context.SaveChangesAsync();
                return new GenericResponse{
                    IsSuccess = true,
                    IsCreated = true
                };
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RegisterGetDTO>> GetRegisters()
        {
            var record = await _context.Registers.Where(r => r.IsActive.Equals(0)).ToListAsync();
            var result = _mapper.Map<IEnumerable<RegisterGetDTO>>(record);
            return result;
        }
        public async Task<GenericResponse> PostRegisters(RegisterPostRequest request)
        {
            try
            {
                var record = new Entities.Register()
                {
                    CPF = request.CPF,
                    Email = request.Email,
                    Role = request.Role == "Coordenador" ? Roles.Manager : Roles.Teacher,
                    Name = request.Name,
                    Password = request.Password,
                    IsActive = request.IsActive
                };
                await this._context.Registers.AddAsync(record);
                await this._context.SaveChangesAsync();
                return new GenericResponse
                {
                    IsSuccess = true,
                    Status = 200
                };
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}