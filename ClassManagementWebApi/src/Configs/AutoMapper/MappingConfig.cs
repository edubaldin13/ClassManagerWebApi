using AutoMapper;
using ClassManagementWebApi.Entities.Teacher;
using ClassManagementWebApi.src.DTO.ClassSubject;
using ClassManagementWebApi.src.DTO.GraduationCourse;
using ClassManagementWebApi.src.DTO.Manager;
using ClassManagementWebApi.src.DTO.Register;
using ClassManagementWebApi.src.DTO.Teacher;
using ClassManagementWebApi.src.DTO.User;
using ClassManagementWebApi.src.Entities;

namespace ClassManagementWebApi.src.Configs.AutoMapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //adicionar os CreateMap(Entidade, Dto)
            CreateMap<User, UserGetDTO>().ReverseMap();
            CreateMap<GraduationCourse, GraduationCourseGetDTO>().ReverseMap();
            CreateMap<Manager, ManagerGetDTO>().ReverseMap();
            CreateMap<Teacher, TeacherGetDTO>().ReverseMap();
            CreateMap<Teacher, TeacherWithoutCourseGetDTO>().ReverseMap();
            CreateMap<Register, RegisterGetDTO>().ReverseMap();
            CreateMap<IEnumerable<GraduationCourse>, IEnumerable<GraduationCourseGetDTO>>().ReverseMap();
        }
    }
}
