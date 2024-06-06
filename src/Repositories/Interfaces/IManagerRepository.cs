using class_management_web_api.src.DTO.Manager;

namespace class_management_web_api.src.Repositories
{
    public interface IManagerRepository
    {
        public Task<IEnumerable<ManagerGetDTO>> GetAll ();
    }
}