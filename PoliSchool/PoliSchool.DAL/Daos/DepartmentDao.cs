
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class DepartmentDao : IDepartmentDao
    {
        private readonly SchoolDbContext schoolDb;

        public DepartmentDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }

        public List<DepartmentModel> GetDepartments()
        {
            var deptos = this.schoolDb.Departments.Where(depto => !depto.Deleted).Select(depto => new DepartmentModel()
            {
                DepartmentId = depto.DepartmentId,
                Name = depto.Name,
            }).ToList();
            return deptos;
        }
    }
}
