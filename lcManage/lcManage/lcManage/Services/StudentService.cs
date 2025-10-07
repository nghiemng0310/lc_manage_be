using lcManage.Models;
using lcManage.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lcManage.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateAsync(Student model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            await _context.Students.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;

        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(student == null)
            {
                throw new NotImplementedException();
            }
            student.UpdatedDate = DateTime.Now;
            student.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Student> DetailsAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            return student;
        }

        public async Task<List<Student>> GetListAsync()
        {
            return await _context.Students.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Student> UpdateAsync(Student model)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (student == null)
            {
                throw new NotImplementedException();
            }
            student.UpdatedDate = DateTime.Now;
            student.UpdateModel(model);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
