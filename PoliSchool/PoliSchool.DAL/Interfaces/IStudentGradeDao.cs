
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IStudentGradeDao
    {
        void SaveGrade(StudentGrade studentGrade);
        void UpdateGrade(StudentGrade studentGrade);
        void RemoveGrade (StudentGrade studentGrade);

        List<StudentGradeModel> GetStudentGrades();
        StudentGradeModel GetStudentGradeById(int EnrollmentId);

    }
}
