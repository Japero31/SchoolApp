

namespace PoliSchool.DAL.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string Name { get { return string.Concat(this.FirstName, " ", this.LastName); } }
        public DateTime EnrollmentDate { get; set; }
        public DateTime CreationDate { get; set; }


        public string CreationDateDisplay
        {
            get { return this.CreationDate.ToString("dd/MM/yyyy"); }
        }

        public string EnrollmentDateDisplay
        {
            get { return this.EnrollmentDate.ToString("dd/MM/yyyy"); }
        }
    }
}
