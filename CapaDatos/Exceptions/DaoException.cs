using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Exceptions
{
    public class DaoException : Exception
    {
        private string message;
        public DaoException(string message)
        {
            this.message = message;
        }
        public string getMessage()
        {
            return message;
        }
    }
}
