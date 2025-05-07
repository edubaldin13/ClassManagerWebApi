using ClassManagementWebApi.src.DTO.ClassSubject;
using ClassManagementWebApi.src.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ClassManagementWebApi.src.Controllers
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
