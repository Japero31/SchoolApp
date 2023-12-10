namespace PoliSchool.Web.Models
{
    public class OnsiteCourseListModel
    {
        public int CourseId { get; set; }
        public string? Location { get; set; }
        public string? Days { get; set; }
        public DateTime Time { get; set; }
        public string? TimeDisplay { get; set; }
    }
}
