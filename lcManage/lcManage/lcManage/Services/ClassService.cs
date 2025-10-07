using lcManage.Models;
using lcManage.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lcManage.Services
{
    public class ClassService : IClassService
    {
        private readonly AppDbContext _context;

        public ClassService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Class> CreateAsync(Class model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            await _context.Classes.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;

        }

        public async Task DeleteAsync(int id)
        {
            var classDb = await _context.Classes.FirstOrDefaultAsync(x => x.Id == id);
            if(classDb == null)
            {
                throw new NotImplementedException();
            }
            classDb.UpdatedDate = DateTime.Now;
            classDb.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Class> DetailsAsync(int id)
        {
            var classDb = await _context.Classes.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            return classDb;
        }

        public async Task<List<Class>> GetListAsync()
        {
            return await _context.Classes.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Class> UpdateAsync(Class model)
        {
            var classDb = await _context.Classes.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (classDb == null)
            {
                throw new NotImplementedException();
            }
            classDb.UpdatedDate = DateTime.Now;
            classDb.UpdateModel(model);
            await _context.SaveChangesAsync();
            return classDb;
        }
    }
}
