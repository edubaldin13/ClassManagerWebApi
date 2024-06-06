using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using class_management_web_api.src.Contexts;
using class_management_web_api.src.DTO.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace class_management_web_api.src.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public UserRepository( ApplicationDbContext context
                             , IMapper mapper
                             , IConfiguration configuration){
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserGetDTO>> GetUsers(){
        var record = await _context.Users.ToListAsync();
        var result = _mapper.Map<IEnumerable<UserGetDTO>>(record);
        return result;
        }
    }
}