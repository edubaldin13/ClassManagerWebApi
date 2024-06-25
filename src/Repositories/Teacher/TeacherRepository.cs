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
using class_management_web_api.src.DTO;
using class_management_web_api.src.DTO.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace class_management_web_api.src.Repositories.Teacher
{
    public class TeacherRepository : ITeacherRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public TeacherRepository( ApplicationDbContext context
                             , IMapper mapper
                             , IConfiguration configuration){
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TeacherGetDTO>> GetTeachers(){
        var record = await _context.Teachers.Where(r => r.GraduationCourseId != null).Include(r => r.GraduationCourse).ToListAsync();
        var result = new List<TeacherGetDTO>();
        foreach (var item in record){
            result.Add(new TeacherGetDTO {
                CPF = item.CPF,
                Email = item.Email,
                Name = item.Name,
                GraduationCourseName = item.GraduationCourse.Name,
                GraduationCourseId = item.GraduationCourseId
            });
        }
        return result;
        }

        public async Task<IEnumerable<TeacherWithoutCourseGetDTO>> GetTeachersWithoutCourse()
        {
            var record = await _context.Teachers.Where(r => r.GraduationCourseId.Equals(null)).ToListAsync();
            var result = _mapper.Map<IEnumerable<TeacherWithoutCourseGetDTO>>(record);
            return result;
        }

        public async Task<GenericResponse> UpdateTeacherCourse(Guid courseId, Guid teacherId)
        {
            try
            {
                var record = await _context.Teachers.FirstOrDefaultAsync(r => r.TeacherId.Equals(teacherId));
                if (record != null){
                    record.GraduationCourseId = courseId;
                    _context.Update(record);
                    await _context.SaveChangesAsync();
                    return new GenericResponse(){
                        IsSuccess = true
                    };
                }
                    return new GenericResponse(){
                        IsSuccess = false
                    };
            }
            catch (System.Exception ex)
            {
                    return new GenericResponse(){
                        IsSuccess = false
                    };
                 // TODO
            }
        }
    }
}