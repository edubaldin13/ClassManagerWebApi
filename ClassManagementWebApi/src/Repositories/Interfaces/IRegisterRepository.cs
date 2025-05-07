using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.Register;
using ClassManagementWebApi.src.Requests;

namespace ClassManagementWebApi.src.Repositories
{
    public interface IRegisterRepository
    {
        public Task<IEnumerable<RegisterGetDTO>> GetRegisters();
        public Task<GenericResponse> PostRegisters(RegisterPostRequest request);
        public Task<GenericResponse> ActivateRegister(int id);
    }
}