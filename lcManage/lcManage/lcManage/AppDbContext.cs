﻿using lcManage.Models;
using Microsoft.EntityFrameworkCore;

namespace lcManage
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassPerson> ClassPersons { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }
    }
}
