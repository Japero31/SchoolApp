using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public  class OnsiteCourseDao : IOnsiteCourseDao
    {
        private readonly SchoolDbContext schoolDb;

        public OnsiteCourseDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }

        public OnsiteCourseModel GetOnsiteCourseById(int CourseId)
        {

            OnsiteCourseModel model = new OnsiteCourseModel();
            try
            {
                OnsiteCourse? onsiteCourse = schoolDb.OnsiteCourses.Find(CourseId);

                if (onsiteCourse is null)
                    throw new OnsiteCourseException("La clase presencial no se encuentra registrada");

                model.CourseId = onsiteCourse.CourseId;
                model.Location = onsiteCourse.Location;
                model.Time = onsiteCourse.Time;
                model.Days = onsiteCourse.Days;

            }
            catch (Exception ex)
            {
                throw new OnsiteCourseException(ex.Message);
            }
            return model;
        }

        public List<OnsiteCourseModel> GetOnsiteCourses()
        {
            List<OnsiteCourseModel> onsiteCourses = new List<OnsiteCourseModel>();
            try
            {
                var query = from osc in this.schoolDb.OnsiteCourses
                            select new OnsiteCourseModel
                            {
                                Time = osc.Time,
                                CourseId = osc.CourseId,
                                Location = osc.Location,
                                Days = osc.Days,
                            };
                onsiteCourses = query.ToList();
            }

           
            catch (Exception ex)
            {
                throw new OnsiteCourseException(ex.Message);
            }
            return onsiteCourses;
        }

        public void RemoveOnsiteCourse(OnsiteCourse onsiteCourse)
        {
            try
            {
                OnsiteCourse? onsiteToRemove = this.schoolDb.OnsiteCourses.Find(onsiteCourse.CourseId);

                if (onsiteCourse is null)
                    throw new OnlineCourseDaoException("El curso presencial no se encuentra registrado");

                onsiteToRemove.Location = onsiteCourse.Location;
                onsiteToRemove.CourseId = onsiteCourse.CourseId;
                onsiteToRemove.Days = onsiteCourse.Days;
                onsiteToRemove.Time = onsiteCourse.Time;

            }
            catch (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
        }

        public void SaveOnsiteCourse(OnsiteCourse onsiteCourse)
        {
            try
            {
                if (onsiteCourse is null)
                    throw new OnsiteCourseException("La clase debe ser instanciada");

                this.schoolDb.OnsiteCourses.Add(onsiteCourse);
                this.schoolDb.SaveChanges();
            }catch  (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
        }

        public void UpdateOnsiteCourse(OnsiteCourse onsiteCourse)
        {
            try 
            {
                OnsiteCourse? onsiteToUpdate = this.schoolDb.OnsiteCourses.Find(onsiteCourse.CourseId);

                if (onsiteToUpdate is null)
                    throw new InstructorDaoException("El estudiante no se encuentra registrado");

                onsiteToUpdate.Location = onsiteCourse.Location;
                onsiteToUpdate.CourseId = onsiteCourse.CourseId;
                onsiteToUpdate.Days = onsiteCourse.Days;
                onsiteToUpdate.Time = onsiteCourse.Time;

                this.schoolDb.OnsiteCourses.Update(onsiteToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
        }
    }
}
