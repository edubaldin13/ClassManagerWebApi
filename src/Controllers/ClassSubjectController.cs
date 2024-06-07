using class_management_web_api.src.DTO.ClassSubject;
using class_management_web_api.src.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace class_management_web_api.src.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClassSubjectController : Controller
    {
        private readonly IClassSubjectRepository _managerRepository;
        public ClassSubjectController(IClassSubjectRepository managerRepository){
            _managerRepository = managerRepository;
        }
        [HttpGet()]
        public Task<IEnumerable<ClassSubjectGetDTO>> GetClassSubjects()
        {
            return _managerRepository.GetClassSubjects();
        }
        // [HttpPost()]
        // public Task<IEnumerable<ClassSubjectGetDTO>> PostClassSubject()
        // {
        //     return _managerRepository.PostClassSubjects();
        // }
    }
}
