
namespace PoliSchool.DAL.Models
{
    public class InstructorModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string Name 
        { 
            get 
            { 
             return string.Concat(this.FirstName, " ", this.LastName); 
            } 
        
        }    
        public DateTime HireDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string CreationDateDisplay
        {
            get { return this.CreationDate.ToString("dd/MM/yyyy"); }
        }

        public string HireDateDisplay
        {
            get { return this.HireDate.ToString("dd/MM/yyyy"); }
        }
    }
}
