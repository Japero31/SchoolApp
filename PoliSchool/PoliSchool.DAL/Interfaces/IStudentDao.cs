

using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IStudentDao
    {
        void SaveStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent (Student student);

        List<StudentModel> GetStudents();

        StudentModel GetStudentById(int studentId);

    }
}
