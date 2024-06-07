using class_management_web_api.src.DTO.ClassSubject;

namespace class_management_web_api.src.Repositories
{
    public interface IClassSubjectRepository
    {
        public Task<IEnumerable<ClassSubjectGetDTO>> GetClassSubjects ();
        // public Task<> PostClassSubjects();
    }
}