using ClassManagementWebApi.src.DTO.Manager;

namespace ClassManagementWebApi.src.Repositories
{
    public interface IManagerRepository
    {
        public Task<IEnumerable<ManagerGetDTO>> GetAll ();
    }
}