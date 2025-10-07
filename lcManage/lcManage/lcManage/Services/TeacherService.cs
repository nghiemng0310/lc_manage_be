using lcManage.Models;
using lcManage.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lcManage.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _context;

        public TeacherService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> CreateAsync(Teacher model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            await _context.Teachers.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;

        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if(teacher == null)
            {
                throw new NotImplementedException();
            }
            teacher.UpdatedDate = DateTime.Now;
            teacher.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Teacher> DetailsAsync(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            return teacher;
        }

        public async Task<List<Teacher>> GetListAsync()
        {
            return await _context.Teachers.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Teacher> UpdateAsync(Teacher model)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (teacher == null)
            {
                throw new NotImplementedException();
            }
            teacher.UpdatedDate = DateTime.Now;
            teacher.UpdateModel(model);
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
