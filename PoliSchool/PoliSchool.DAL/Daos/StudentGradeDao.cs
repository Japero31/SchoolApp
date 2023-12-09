
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class StudentGradeDao : IStudentGradeDao
    {
        private readonly SchoolDbContext schoolDb;

        public StudentGradeDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }

        public StudentGradeModel GetStudentGradeById(int EnrollmentId)
        {
            StudentGradeModel model = new StudentGradeModel();
            try
            {
                StudentGrade? studentGrade = schoolDb.StudentGrades.Find(EnrollmentId);

                if (studentGrade is null)
                    throw new StudentGradeDaoException("Las calificaciones no se encuentran registrados");

                model.EnrollmentId = studentGrade.EnrollmentId;
                model.StudentId = studentGrade.StudentId;
                model.CourseId = studentGrade.CourseId;
                model.Grade = studentGrade.Grade;
            }catch (Exception ex)
            {
                throw new StudentGradeDaoException(ex.Message);
            }
            return model;
        }

        public List<StudentGradeModel> GetStudentGrades()
        {
            List<StudentGradeModel> studentGrades = new List<StudentGradeModel>();
            try
            {
                var query = from sg in this.schoolDb.StudentGrades
                            join cou in this.schoolDb.Courses on sg.CourseId equals cou.CourseId
                            join st in this.schoolDb.Students on sg.StudentId equals st.Id
                            select new StudentGradeModel
                            {
                                EnrollmentId = sg.EnrollmentId,
                                StudentId = st.Id,
                                CourseId = cou.CourseId,
                                Grade = sg.Grade,
                            };

                studentGrades = query.ToList();
            }
            catch (Exception ex)
            {
                throw new StudentGradeDaoException(ex.Message);
            }
            return studentGrades;
        }


        public void RemoveGrade(StudentGrade studentGrade)
        {
            try
            {
                StudentGrade? gradeToRemove = this.schoolDb.StudentGrades.Find(studentGrade.EnrollmentId);

                if (gradeToRemove is null)
                    throw new StudentGradeDaoException("Las calificaciones no se encuentran registradas");

                gradeToRemove.EnrollmentId = studentGrade.EnrollmentId;
                gradeToRemove.StudentId = studentGrade.StudentId;
                gradeToRemove.CourseId = studentGrade.CourseId;
                gradeToRemove.Grade = studentGrade.Grade;

                this.schoolDb.StudentGrades.Update(gradeToRemove);
                this.schoolDb.SaveChanges();
            }catch (Exception ex)
            {
                throw new StudentGradeDaoException(ex.Message);
            }
        }

        public void SaveGrade(StudentGrade studentGrade)
        {
            try
            {
                if (studentGrade is null)
                    throw new StudentGradeDaoException("La clase debe ser instanciada");

                this.schoolDb.StudentGrades.Add(studentGrade);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StudentGradeDaoException(ex.Message);
            }
        }

        public void UpdateGrade(StudentGrade studentGrade)
        {
            try
            {
                StudentGrade? gradeToUpdate = this.schoolDb.StudentGrades.Find(studentGrade.EnrollmentId);

                if (gradeToUpdate is null)
                    throw new StudentDaoException("Las calificaciones no se encuentran registradas");

                gradeToUpdate.Grade = studentGrade.Grade;
                gradeToUpdate.StudentId = studentGrade.StudentId;
                gradeToUpdate.CourseId = studentGrade.CourseId;

                this.schoolDb.StudentGrades.Update(gradeToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StudentGradeDaoException(ex.Message);
            }
        }
    }
}
