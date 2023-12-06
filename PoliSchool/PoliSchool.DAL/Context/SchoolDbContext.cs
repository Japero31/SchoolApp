using Microsoft.EntityFrameworkCore;
using PoliSchool.DAL.Entities;

namespace PoliSchool.DAL.Context
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base (options) 
        {
            
        }   

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }
        public DbSet<OnsiteCourse> OnsiteCourses { get;set; }
        public DbSet<StudentGrade> StudentGrades { get;set; }

    }
}
