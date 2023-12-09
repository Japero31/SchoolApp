
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;
using PoliSchool.DAL.Exceptions;

namespace PoliSchool.DAL.Daos
{
    public class DepartmentDao : IDepartmentDao
    {
        private readonly SchoolDbContext schoolDb;

        public DepartmentDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }

        public DepartmentModel GetDepartmentById(int DepartmentId)
        {
            DepartmentModel model = new DepartmentModel();
            try
            {
                Department? department = schoolDb.Departments.Find(DepartmentId);

                if (department is null)
                    throw new DepartmentDaoException("Departamento no registrado");

                model.StartDate = department.StartDate;
                model.Name = department.Name;
                model.DepartmentId = department.DepartmentId;
                model.Budget = department.Budget;
                model.Administrator = department.Administrator.Value;
                
                    
                
            }
            catch (Exception ex)
            {
                throw new DepartmentDaoException(ex.Message);
            }
            return model;
        }

        public List<DepartmentModel> GetDepartments()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            try
            {
                var query = from dep in this.schoolDb.Departments
                            select new DepartmentModel()
                            {
                                Name = dep.Name,
                                DepartmentId = dep.DepartmentId,
                                Budget = dep.Budget,
                                Administrator = dep.Administrator.Value,
                                StartDate = dep.StartDate,
                               

                            };

                departments = query.ToList();
            }catch (Exception ex)
            {
                throw new DepartmentDaoException(ex.Message);
            }
            return departments;
        }

        public void RemoveDepartment(Department department)
        {
            try
            {
                Department? departmentToRemove = this.schoolDb.Departments.Find(department.DepartmentId);

                if (departmentToRemove is null)
                    throw new CourseDaoException("El Curso no se encuentra registrado.");


                departmentToRemove.Deleted = department.Deleted;
                departmentToRemove.DeletedDate = department.DeletedDate;
                departmentToRemove.UserDeleted = department.UserDeleted;

                this.schoolDb.Departments.Update(departmentToRemove);
                this.schoolDb.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new DepartmentDaoException(ex.Message);
            }
        }

        public void SaveDepartment(Department department)
        {
            try
            {
                if (department is null)
                    throw new DepartmentDaoException("la clase debe de ser instaciada.");


                this.schoolDb.Departments.Add(department);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DepartmentDaoException(ex.Message);
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                Department? departmentToUpdate = this.schoolDb.Departments.Find(department.DepartmentId);

                if (departmentToUpdate is null)
                    throw new DepartmentDaoException("El curso no se encuentra registrado.");


                departmentToUpdate.ModifyDate = department.ModifyDate;
                departmentToUpdate.UserMod = department.UserMod;
                departmentToUpdate.DepartmentId = department.DepartmentId;
                departmentToUpdate.Name = department.Name;
                departmentToUpdate.CreationDate = department.CreationDate;
                departmentToUpdate.StartDate = department.StartDate;
                departmentToUpdate.Budget = department.Budget;
                departmentToUpdate.Administrator = department.Administrator;


                this.schoolDb.Departments.Update(departmentToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new DepartmentDaoException(ex.Message);
            }
        }
    }
}
