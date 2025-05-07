using ClassManagementWebApi.src.DTO.User;

namespace ClassManagementWebApi.src.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserGetDTO>> GetUsers();
    }
}