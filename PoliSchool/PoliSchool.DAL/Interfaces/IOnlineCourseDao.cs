using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;


namespace PoliSchool.DAL.Interfaces
{
    public interface IOnlineCourseDao
    {
        void SaveOnlineCourse (OnlineCourse onlineCourse);
        void UpdateOnlineCourse(OnlineCourse onlineCourse);
        void RemoveOnlineCourse(OnlineCourse onlineCourse);

        OnlineCourseModel GetOnlineCourseById(int CourseId);

        List<OnlineCourseModel> GetOnlineCourses();
    }
}
