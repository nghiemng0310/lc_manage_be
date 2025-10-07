using lcManage.Models;

namespace lcManage.ServiceInterfaces
{
    public interface IClassPersonService
    {
        Task<List<ClassPerson>> GetListAsync();
        Task<ClassPerson> CreateAsync(ClassPerson model);
        Task<ClassPerson> UpdateAsync(ClassPerson model);
        Task<ClassPerson> DetailsAsync(int id);
        Task DeleteAsync(int id);
    }
}
