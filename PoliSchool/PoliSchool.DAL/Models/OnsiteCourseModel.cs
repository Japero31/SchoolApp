

namespace PoliSchool.DAL.Models
{
    public class OnsiteCourseModel
    {
        public int CourseId { get; set; }
        public string? Location { get; set; }
        public string? Days { get; set; }
        public DateTime Time { get; set; }

        public string TimeDisplay
        {
            get { return this.Time.ToString("dd/MM/yyyy");  }
        }

    }
}
