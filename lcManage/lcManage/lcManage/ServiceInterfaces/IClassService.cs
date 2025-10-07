using lcManage.Models;

namespace lcManage.ServiceInterfaces
{
    public interface IClassService
    {
        Task<List<Class>> GetListAsync();
        Task<Class> CreateAsync(Class model);
        Task<Class> UpdateAsync(Class model);
        Task<Class> DetailsAsync(int id);
        Task DeleteAsync(int id);
    }
}
