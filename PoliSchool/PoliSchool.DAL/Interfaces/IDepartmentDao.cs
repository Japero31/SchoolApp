using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliSchool.DAL.Interfaces
{
    public interface IDepartmentDao
    {
        void SaveDepartment(Department department);
        void UpdateDepartment(Department department);
        void RemoveDepartment(Department department);

        DepartmentModel GetDepartmentById(int DepartmentId);
        List<DepartmentModel> GetDepartments();
       
    }
}
