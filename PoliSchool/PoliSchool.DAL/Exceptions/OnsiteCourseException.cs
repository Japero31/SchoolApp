using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliSchool.DAL.Exceptions
{
    public class OnsiteCourseException : Exception
    {
        public OnsiteCourseException(string message) : base(message)
        {
            
        }
    }
}
