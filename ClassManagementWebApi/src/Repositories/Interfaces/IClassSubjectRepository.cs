using ClassManagementWebApi.src.DTO.ClassSubject;

namespace ClassManagementWebApi.src.Repositories
{
    public interface IClassSubjectRepository
    {
        public Task<IEnumerable<ClassSubjectGetDTO>> GetClassSubjects ();
        // public Task<> PostClassSubjects();
    }
}