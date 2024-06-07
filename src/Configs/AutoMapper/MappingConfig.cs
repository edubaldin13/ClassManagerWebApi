using AutoMapper;
using class_management_web_api.src.DTO.GraduationCourse;
using class_management_web_api.src.DTO.Manager;
using class_management_web_api.src.DTO.Teacher;
using class_management_web_api.src.DTO.User;
using class_management_web_api.src.Entities;

namespace class_management_web_api.src.Configs.AutoMapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            //adicionar os CreateMap(Entidade, Dto)
            CreateMap<User, UserGetDTO>().ReverseMap();
            CreateMap<GraduationCourse, GraduationCourseGetDTO>().ReverseMap();
            CreateMap<Manager, ManagerGetDTO>().ReverseMap();
            CreateMap<Teacher, TeacherGetDTO>().ReverseMap();
            CreateMap<IEnumerable<GraduationCourse>, IEnumerable<GraduationCourseGetDTO>>().ReverseMap();
            //adicionar os CreateMap(Entidade, Request)
        }
    }
}
