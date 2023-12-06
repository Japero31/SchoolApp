
using PoliSchool.DAL.Core;

namespace PoliSchool.DAL.Entities
{
    public class Student : Person
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }

    }
}
