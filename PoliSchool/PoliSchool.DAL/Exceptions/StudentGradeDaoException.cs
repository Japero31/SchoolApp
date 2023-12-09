using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliSchool.DAL.Exceptions
{
    public class StudentGradeDaoException : Exception
    {
        public StudentGradeDaoException(string message) : base(message) 
        {
            
        }
    }
}
