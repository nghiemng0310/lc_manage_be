using lcManage.Models;
using lcManage.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lcManage.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetListAsync()
        {
            return await _context.Courses.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Course> CreateAsync(Course model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            await _context.Courses.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Course> UpdateAsync(Course model)
        {
            var courseInDb = await _context.Courses
                                             .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (courseInDb == null)
            {
                throw new NotImplementedException();
            }
            courseInDb.UpdatedDate = DateTime.Now;

            courseInDb.UpdateModel(model);

            await _context.SaveChangesAsync();

            return courseInDb;
        }

        public async Task<Course> DetailsAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            return course;
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course == null)
            {
                throw new NotImplementedException();
            }
            course.UpdatedDate = DateTime.Now;
            course.IsDeleted = true;

            await _context.SaveChangesAsync();
        }
    }
}
