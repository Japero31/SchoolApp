
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;
using PoliSchool.DAL.Exceptions;

namespace PoliSchool.DAL.Daos
{
    public class InstructorDao : IInstructorDao
    {
        private readonly SchoolDbContext schoolDb;

        public InstructorDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }

        public InstructorModel GetInstructorById(int instructorId)
        {
            InstructorModel model = new InstructorModel();
            try
            {
                Instructor? instructor = schoolDb.Instructors.Find(instructorId);

                if (instructor is null)
                    throw new InstructorDaoException("El instructor no se encuentra registrado");

                model.FirstName = instructor.FirstName;
                model.LastName = instructor.LastName;
                model.CreationDate = instructor.CreationDate;
                model.HireDate = instructor.HireDate.Value;
                model.Id = instructor.Id;

            }catch (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
            return model;
        }

        public List<InstructorModel> GetInstructors()
        {
            List<InstructorModel> instructors = new List<InstructorModel>();
            try
            {
                var query = from it in this.schoolDb.Instructors
                            where it.Deleted == false
                            orderby it.CreationDate descending
                            select new InstructorModel
                            {
                                CreationDate = it.CreationDate,
                                FirstName = it.FirstName,
                                LastName = it.LastName,
                                Id = it.Id,
                                HireDate = it.HireDate.Value,
                            };
                instructors = query.ToList();
            }catch (Exception ex)
            {
                throw new InstructorDaoException (ex.Message);
            }
            return instructors;
        }

        public void RemoveInstructor(Instructor instructor)
        {
            try
            {
                Instructor? instructorToRemove = this.schoolDb.Instructors.Find(instructor.Id);
                if (instructorToRemove is null)
                    throw new InstructorDaoException("El instructor no se encuentra registrado");

                instructorToRemove.Deleted = instructor.Deleted;
                instructorToRemove.DeletedDate = instructor.DeletedDate;
                instructorToRemove.UserDeleted = instructor.UserDeleted;

                this.schoolDb.Instructors.Update(instructorToRemove);
                this.schoolDb.SaveChanges();

            }
            catch  (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
        }

        public void SaveInstructor(Instructor instructor)
        {
            try
            {
                if (instructor is null)
                    throw new InstructorDaoException("La clase debe ser instanciada");

                this.schoolDb.Instructors.Add(instructor);
                this.schoolDb.SaveChanges();
            }catch (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
        }

        public void UpdateInstructor(Instructor instructor)
        {
            try
            {
                Instructor? instructorToUpdate = this.schoolDb.Instructors.Find(instructor.Id);

                if (instructorToUpdate is null)
                    throw new InstructorDaoException("El estudiante no se encuentra registrado");

                instructorToUpdate.ModifyDate = instructor.ModifyDate;
                instructorToUpdate.UserMod = instructor.UserMod;
                instructorToUpdate.Id = instructor.Id;
                instructorToUpdate.FirstName = instructor.FirstName;
                instructorToUpdate.LastName = instructor.LastName;
                instructorToUpdate.HireDate = instructor.HireDate;

                this.schoolDb.Instructors.Update(instructorToUpdate);
                this.schoolDb.SaveChanges();
            }catch (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
        }
    }
}
