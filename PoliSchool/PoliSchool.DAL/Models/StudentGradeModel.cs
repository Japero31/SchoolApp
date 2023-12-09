
namespace PoliSchool.DAL.Models
{
    public class StudentGradeModel
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set;}
        public int CourseId { get; set;}
        public decimal? Grade { get; set; }


    }
}
