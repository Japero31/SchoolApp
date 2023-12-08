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
        List<DepartmentModel> GetDepartments();
       
    }
}
