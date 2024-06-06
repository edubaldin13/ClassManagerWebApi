using class_management_web_api.src.DTO.Manager;
using class_management_web_api.src.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace class_management_web_api.src.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ManagerController : Controller
    {
        private readonly IManagerRepository _managerRepository;
        public ManagerController(IManagerRepository managerRepository){
            _managerRepository = managerRepository;
        }
        [HttpGet()]
        public Task<IEnumerable<ManagerGetDTO>> GetManagers()
        {
            return _managerRepository.GetAll();
        }
    }
}
