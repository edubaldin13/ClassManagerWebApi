using AutoMapper;
using class_management_web_api.src.DTO.User;
using class_management_web_api.src.Entities;

namespace class_management_web_api.src.Configs.AutoMapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            //adicionar os CreateMap(Entidade, Dto)
            CreateMap<User, UserGetDTO>().ReverseMap();
            //adicionar os CreateMap(Entidade, Request)
        }
    }
}
