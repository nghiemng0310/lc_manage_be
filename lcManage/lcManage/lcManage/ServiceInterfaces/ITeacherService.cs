using lcManage.Models;

namespace lcManage.ServiceInterfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetListAsync();
        Task<Teacher> CreateAsync(Teacher model);
        Task<Teacher> UpdateAsync(Teacher model);
        Task<Teacher> DetailsAsync(int id);
        Task DeleteAsync(int id);
    }
}
