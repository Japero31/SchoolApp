
using PoliSchool.DAL.Core;

namespace PoliSchool.DAL.Entities
{
    public class Course : BaseEntity
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

    }
}
