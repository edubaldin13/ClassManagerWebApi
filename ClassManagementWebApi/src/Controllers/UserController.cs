using ClassManagementWebApi.src.DTO.User;
using ClassManagementWebApi.src.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ClassManagementWebApi.src.Controllers
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
