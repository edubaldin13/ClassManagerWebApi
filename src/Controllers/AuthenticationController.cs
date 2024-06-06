using class_management_web_api.src.DTO.Authentication;
using class_management_web_api.src.Repositories;
using class_management_web_api.src.Requests.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace class_management_web_api.src.Controllers
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
