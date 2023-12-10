using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;


namespace PoliSchool.DAL.Interfaces
{
    public interface IOnsiteCourseDao
    {
        void SaveOnsiteCourse(OnsiteCourse onsiteCourse);
        void UpdateOnsiteCourse(OnsiteCourse onsiteCourse);
        void RemoveOnsiteCourse(OnsiteCourse onsiteCourse);

        OnsiteCourseModel GetOnsiteCourseById(int CourseId);
        List<OnsiteCourseModel> GetOnsiteCourses();
    }
}
