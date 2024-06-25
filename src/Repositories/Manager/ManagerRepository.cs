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
using class_management_web_api.src.DTO.Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace class_management_web_api.src.Repositories.Manager
{
    public class ManagerRepository : IManagerRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public ManagerRepository( ApplicationDbContext context
                             , IMapper mapper
                             , IConfiguration configuration){
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ManagerGetDTO>> GetAll(){
        // var record = await _context.Managers.Where(r => r.GraduationCourses.Where(r =>r.)).ToListAsync();
        var record = await _context.Managers
        .GroupJoin(
            _context.ClassSubjects,
            manager => manager.ManagerId,
            @class => @class.ManagerId,
            (manager, classes) => new { Manager = manager, Classes = classes }
        )
        .Where(mc => mc.Classes.Any())
        .Select(mc => mc.Manager)
        .ToListAsync();
        var result = _mapper.Map<IEnumerable<ManagerGetDTO>>(record);
        return result;
        }
    }
}