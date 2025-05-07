using ClassManagementWebApi.src.DTO.Authentication;
using ClassManagementWebApi.src.Repositories;
using ClassManagementWebApi.src.Requests.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ClassManagementWebApi.src.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationController(IAuthenticationRepository authenticationRepository){
            _authenticationRepository = authenticationRepository;
        }
        [HttpPost("login")]
        public Task<AuthenticationPostDTO> Login([FromBody] AuthenticationPostRequest request)
        {
            return _authenticationRepository.Authenticate(request);
        }
    }
}
