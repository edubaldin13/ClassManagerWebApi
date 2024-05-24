using class_management_web_api.src.DTO.Authentication;
using class_management_web_api.src.Requests.Authentication;
using Microsoft.AspNetCore.Mvc;
namespace class_management_web_api.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public Task<AuthenticationPostDTO> Post([FromBody] AuthenticationPostRequest request)
        {
            return null;
        }
    }
}
