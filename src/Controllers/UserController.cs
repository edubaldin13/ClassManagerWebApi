using class_management_web_api.src.DTO.User;
using class_management_web_api.src.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace class_management_web_api.src.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository){
            _userRepository = userRepository;
        }
        [HttpGet()]
        public Task<IEnumerable<UserGetDTO>> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
