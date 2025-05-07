using ClassManagementWebApi.src.DTO.Manager;
using ClassManagementWebApi.src.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ClassManagementWebApi.src.Controllers
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
