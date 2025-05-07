using AutoMapper;
using ClassManagementWebApi.src.Contexts;
using ClassManagementWebApi.src.DTO.ClassSubject;
using Microsoft.EntityFrameworkCore;
namespace ClassManagementWebApi.src.Repositories.ClassSubject
{
    public class ClassSubjectRepository : IClassSubjectRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public ClassSubjectRepository( ApplicationDbContext context
                             , IMapper mapper
                             , IConfiguration configuration){
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClassSubjectGetDTO>> GetClassSubjects(){
        var record = await _context.ClassSubjects.ToListAsync();
        var result = _mapper.Map<IEnumerable<ClassSubjectGetDTO>>(record);
        return result;
        }
    }
}