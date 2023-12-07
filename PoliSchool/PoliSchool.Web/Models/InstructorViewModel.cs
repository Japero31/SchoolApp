namespace PoliSchool.Web.Models
{
    public class InstructorViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public DateTime HireDate { get; set; }
        public string Name
        {
            get
            {
                return string.Concat(this.FirstName, " ", this.LastName);
            }
        }
    }
}
