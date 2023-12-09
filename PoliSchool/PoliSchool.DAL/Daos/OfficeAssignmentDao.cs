
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class OfficeAssignmentDao : IOfficeAssignmentDao
    {
        private readonly SchoolDbContext schoolDb;

        public OfficeAssignmentDao(SchoolDbContext schoolDb) 
        {
            this.schoolDb = schoolDb;
        }

        public OfficeAssignmentModel GetOfficeAssignmentById(int InstructorId)
        {
            OfficeAssignmentModel model = new OfficeAssignmentModel();
            try
            {
                OfficeAssignment? officeAssignment = schoolDb.OfficeAssignments.Find(InstructorId);

                if (officeAssignment is null)
                    throw new OfficeAssignmentDaoException("No se encuentra registrado");

                model.Location = officeAssignment.Location;
                model.InstructorId = officeAssignment.InstructorID;
            }catch (Exception ex) 
            {
                throw new OfficeAssignmentDaoException(ex.Message);
            }
            return model;
        }

        public List<OfficeAssignmentModel> GetOfficeAssignments()
        {
            List<OfficeAssignmentModel> offices = new List<OfficeAssignmentModel>();
            try
            {
                var query = from off in this.schoolDb.OfficeAssignments
                            select new OfficeAssignmentModel()
                            {
                                InstructorId = off.InstructorID,
                                Location = off.Location
                            };

                offices = query.ToList();
            }catch (Exception ex)
            {
                throw new OfficeAssignmentDaoException(ex.Message);
            }
            return offices;
        }

        public void RemoveOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                OfficeAssignment? officeToRemove = this.schoolDb.OfficeAssignments.Find(officeAssignment.InstructorID);

                if (officeToRemove is null)
                    throw new OfficeAssignmentDaoException("No se encuentra registrado");

                officeToRemove.Location = officeAssignment.Location;
                officeToRemove.InstructorID = officeAssignment.InstructorID;

                this.schoolDb.OfficeAssignments.Update(officeToRemove);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new OfficeAssignmentDaoException(ex.Message);

            }
        }

        public void SaveOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                if (officeAssignment is null)
                    throw new OfficeAssignmentDaoException("No se encuentra registrado");

                this.schoolDb.OfficeAssignments.Add(officeAssignment);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new OfficeAssignmentDaoException(ex.Message);
            }
        }

        public void UpdateOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                OfficeAssignment? officeToUpdate = this.schoolDb.OfficeAssignments.Find(officeAssignment.InstructorID);

                if (officeToUpdate is null)
                    throw new OfficeAssignmentDaoException("LALALAA");

                officeToUpdate.Location = officeAssignment.Location;
                officeToUpdate.InstructorID=officeAssignment.InstructorID;

                this.schoolDb.OfficeAssignments.Add(officeToUpdate);
                this.schoolDb.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new OfficeAssignmentDaoException(ex.Message);
            }
        }
    }
}
