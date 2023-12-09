using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliSchool.DAL.Exceptions
{
    public class OfficeAssignmentDaoException : Exception
    {
        public OfficeAssignmentDaoException(string message) : base(message)
        {
            
        }
    }
}
