using lcManage.Models;
using lcManage.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lcManage.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly AppDbContext _context;

        public SubjectService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Subject> CreateAsync(Subject model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            await _context.Subjects.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                throw new NotImplementedException();
            }
            customer.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetListAsync()
        {
            return await _context.Subjects.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Subject> UpdateAsync(Subject model)
        {
            var subjectInDb = await _context.Subjects
                                             .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (subjectInDb == null)
            {
                throw new NotImplementedException();
            }
            model.UpdatedDate = DateTime.Now;

            subjectInDb.UpdateModel(model);

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Subject> DetailsAsync(int id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            return subject;
        }
    }
}
