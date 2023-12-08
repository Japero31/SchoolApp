

using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface ICourseDao
    {
        void SaveCourse(Course course);
        void UpdateCourse(Course course);
        void RemoveCourse(Course course);
        List<CourseModel> GetCourses();
        CourseModel GetCourseById(int CourseId);
    }
}
