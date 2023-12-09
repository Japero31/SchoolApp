namespace PoliSchool.Web.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }   
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
