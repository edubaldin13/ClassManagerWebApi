using class_management_web_api.src.DTO;
using class_management_web_api.src.DTO.Register;
using class_management_web_api.src.Requests;

namespace class_management_web_api.src.Repositories
{
    public interface IRegisterRepository
    {
        public Task<IEnumerable<RegisterGetDTO>> GetRegisters();
        public Task<GenericResponse> PostRegisters(RegisterPostRequest request);
        public Task<GenericResponse> ActivateRegister(Guid id);
    }
}