using lcManage.Models;

namespace lcManage.ServiceInterfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetListAsync();
        Task<Student> CreateAsync(Student model);
        Task<Student> UpdateAsync(Student model);
        Task<Student> DetailsAsync(int id);
        Task DeleteAsync(int id);
    }
}
