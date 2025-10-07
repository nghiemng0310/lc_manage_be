using lcManage.Models;

namespace lcManage.ServiceInterfaces
{
    public interface ISubjectTeacherService
    {
        Task<List<SubjectTeacher>> GetListAsync();
        Task<SubjectTeacher> CreateAsync(SubjectTeacher model);
        Task<SubjectTeacher> UpdateAsync(SubjectTeacher model);
        Task<SubjectTeacher> DetailsAsync(int id);
        Task DeleteAsync(int id);
    }
}
