using lcManage.Models;
using lcManage.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lcManage.Services
{
    public class ClassPersonService : IClassPersonService
    {
        private readonly AppDbContext _context;

        public ClassPersonService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassPerson>> GetListAsync()
        {
            return await _context.ClassPersons.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<ClassPerson> CreateAsync(ClassPerson model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            await _context.ClassPersons.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<ClassPerson> UpdateAsync(ClassPerson model)
        {
            var classPerson = await _context.ClassPersons
                                             .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (classPerson == null)
            {
                throw new NotImplementedException();
            }
            classPerson.UpdatedDate = DateTime.Now;

            classPerson.UpdateModel(model);

            await _context.SaveChangesAsync();

            return classPerson;
        }

        public async Task<ClassPerson> DetailsAsync(int id)
        {
            var classPerson = await _context.ClassPersons.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            return classPerson;
        }

        public async Task DeleteAsync(int id)
        {
            var classPerson = await _context.ClassPersons.FirstOrDefaultAsync(x => x.Id == id);
            if (classPerson == null)
            {
                throw new NotImplementedException();
            }
            classPerson.UpdatedDate = DateTime.Now;
            classPerson.IsDeleted = true;

            await _context.SaveChangesAsync();
        }
    }
}
