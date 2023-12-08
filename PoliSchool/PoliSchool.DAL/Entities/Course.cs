
using PoliSchool.DAL.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliSchool.DAL.Entities
{
    [Table("Course")]
    public class Course : BaseEntity
    {

        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

    }
}
