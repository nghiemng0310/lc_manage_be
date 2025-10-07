using lcManage.Models;

namespace lcManage.ServiceInterfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetListAsync();
        Task<Subject> CreateAsync(Subject model);
        Task<Subject> UpdateAsync(Subject model);
        Task<Subject> DetailsAsync(int id);
        Task DeleteAsync(int id);
    }
}
