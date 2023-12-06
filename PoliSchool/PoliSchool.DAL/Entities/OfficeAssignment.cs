using System.ComponentModel.DataAnnotations.Schema;

namespace PoliSchool.DAL.Entities
{
    [Table("OfficeAssignment")]
    public class OfficeAssignment
    {
        public int InstructorID { get; set; }
        public string? Location { get; set; }
        public byte[]? Timestamp { get; set; }

    }
}
