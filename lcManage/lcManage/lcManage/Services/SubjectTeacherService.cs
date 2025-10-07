using lcManage.Models;
using lcManage.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lcManage.Services
{
    public class SubjectTeacherService : ISubjectTeacherService
    {
        private readonly AppDbContext _context;

        public SubjectTeacherService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubjectTeacher>> GetListAsync()
        {
            return await _context.SubjectTeachers.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<SubjectTeacher> CreateAsync(SubjectTeacher model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            await _context.SubjectTeachers.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<SubjectTeacher> UpdateAsync(SubjectTeacher model)
        {
            var subjectTeacher = await _context.SubjectTeachers
                                             .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (subjectTeacher == null)
            {
                throw new NotImplementedException();
            }
            subjectTeacher.UpdatedDate = DateTime.Now;

            subjectTeacher.UpdateModel(model);

            await _context.SaveChangesAsync();

            return subjectTeacher;
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
