

namespace PoliSchool.WebCourse.Data
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreationUser { get; set; }
        public int? UserMod { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}