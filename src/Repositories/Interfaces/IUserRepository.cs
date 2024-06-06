using class_management_web_api.src.DTO.User;

namespace class_management_web_api.src.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserGetDTO>> GetUsers();
    }
}