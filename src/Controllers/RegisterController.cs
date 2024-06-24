using System.Net;
using class_management_web_api.src.DTO;
using class_management_web_api.src.DTO.Register;
using class_management_web_api.src.Repositories;
using class_management_web_api.src.Requests;
using Microsoft.AspNetCore.Mvc;
namespace class_management_web_api.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterController(IRegisterRepository registerRepository){
            _registerRepository = registerRepository;
        }
        [HttpPost]
        public Task<GenericResponse> RegisterUser([FromBody] RegisterPostRequest request)
        {
            return _registerRepository.PostRegisters(request);
        }
        [HttpGet()]
        public Task<IEnumerable<RegisterGetDTO>> GetRegisters()
        {
            return _registerRepository.GetRegisters();
        }
        [HttpPatch("{id:Guid}")]
        public Task<GenericResponse> ActivateRegister([FromRoute] Guid id)
        {
            return _registerRepository.ActivateRegister(id);
        }
    }
}