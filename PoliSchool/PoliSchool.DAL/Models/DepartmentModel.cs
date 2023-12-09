
namespace PoliSchool.DAL.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }
        public int Administrator { get; set; }

        public string StartDateDisplay
        {
            get { return this.StartDate.ToString("dd/MM/yyyy"); }
        }

    }
}
