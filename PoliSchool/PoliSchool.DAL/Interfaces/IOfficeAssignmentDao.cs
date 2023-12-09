
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IOfficeAssignmentDao
    {
        void SaveOfficeAssignment(OfficeAssignment officeAssignment);
        void UpdateOfficeAssignment(OfficeAssignment officeAssignment);
        void RemoveOfficeAssignment(OfficeAssignment officeAssignment);
        List<OfficeAssignmentModel> GetOfficeAssignments();
        OfficeAssignmentModel GetOfficeAssignmentById(int InstructorId);
    }
}
