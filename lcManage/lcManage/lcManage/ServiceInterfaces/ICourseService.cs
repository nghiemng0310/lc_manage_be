using lcManage.Models;

namespace lcManage.ServiceInterfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetListAsync();
        Task<Course> CreateAsync(Course model);
        Task<Course> UpdateAsync(Course model);
        Task<Course> DetailsAsync(int id);
        Task DeleteAsync(int id);
    }
}
