namespace PoliSchool.Web.Models
{
    public class DepartmentListModel
    {
        public int DepartmentId { get; set; }   
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public int Administrator { get; set; }
        
        public string? StartDateDisplay { get; set; }

    }
}
