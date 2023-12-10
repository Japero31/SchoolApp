
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;
using PoliSchool.DAL.Exceptions;

namespace PoliSchool.DAL.Daos
{
    public class OnlineCourseDao : IOnlineCourseDao
    {
        private readonly SchoolDbContext schoolDb;

        public OnlineCourseDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }

        public OnlineCourseModel GetOnlineCourseById(int CourseId)
        {
            OnlineCourseModel model = new OnlineCourseModel();
            try
            {
                OnlineCourse? onlineCourse = schoolDb.OnlineCourses.Find(CourseId);

                if (onlineCourse is  null)

                    throw new OnlineCourseDaoException("El curso no se encuentra registrado");


                model.CourseId = onlineCourse.CourseId;
                model.URL = onlineCourse.Url;
            }
            catch (Exception ex)
            {
                throw new OnlineCourseDaoException(ex.Message);
            }
            return model;
        }

        public List<OnlineCourseModel> GetOnlineCourses()
        {
            List<OnlineCourseModel> onlineCourses = new List<OnlineCourseModel>();
            try
            {
                var query = from onl in this.schoolDb.OnlineCourses
                            join cou in this.schoolDb.Courses on onl.CourseId equals cou.CourseId
                            select new OnlineCourseModel()
                            {
                                CourseId = cou.CourseId,
                                URL = onl.Url,
                            };

                onlineCourses = query.ToList();
            }
            catch (Exception ex)
            {
                throw new OnlineCourseDaoException(ex.Message);
            }

            return onlineCourses;
        }

        public void RemoveOnlineCourse(OnlineCourse onlineCourse)
        {
            try
            {
                OnlineCourse? onlineToRemove = this.schoolDb.OnlineCourses.Find(onlineCourse.CourseId);

                if (onlineToRemove is null)
                    throw new OnlineCourseDaoException("El curso online no se encuentra registrado");

                onlineToRemove.CourseId = onlineCourse.CourseId;
                onlineToRemove.Url = onlineCourse.Url;

            }
            catch (Exception ex)
            {
                throw new OnlineCourseDaoException(ex.Message);
            }
        }

        public void SaveOnlineCourse(OnlineCourse onlineCourse)
        {
            try
            {
                OnlineCourse? onlineToRemove = this.schoolDb.OnlineCourses.Find(onlineCourse.CourseId);

                if (onlineToRemove is null)
                    throw new OnlineCourseDaoException("El curso online no se encuentra registrado");

                onlineToRemove.CourseId = onlineCourse.CourseId;
                onlineToRemove.Url = onlineCourse.Url;

            }
            catch (Exception ex)
            {
                throw new OnlineCourseDaoException(ex.Message);
            }
        }

        public void UpdateOnlineCourse(OnlineCourse onlineCourse)
        {

            try
            {
                OnlineCourse? onlineToUpdate = this.schoolDb.OnlineCourses.Find(onlineCourse.CourseId);

                if (onlineToUpdate is null)
                    throw new OnlineCourseDaoException("El curso online no se encuentra registrado");

                onlineToUpdate.CourseId = onlineCourse.CourseId;
                onlineToUpdate.Url = onlineCourse.Url;

                this.schoolDb.OnlineCourses.Update(onlineToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new OnlineCourseDaoException(ex.Message);
            }
        }
    }
}
