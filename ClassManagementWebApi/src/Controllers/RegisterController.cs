using System.Net;
using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.Register;
using ClassManagementWebApi.src.Repositories;
using ClassManagementWebApi.src.Requests;
using Microsoft.AspNetCore.Mvc;
namespace ClassManagementWebApi.src.Controllers
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
        [HttpPatch("{id:int}")]
        public Task<GenericResponse> ActivateRegister([FromRoute] int id)
        {
            return _registerRepository.ActivateRegister(id);
        }
    }
}