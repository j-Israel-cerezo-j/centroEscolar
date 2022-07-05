using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Exceptions
{
    public class ServiceException : Exception
    {
        private string message;
        public ServiceException(string message)
        {
            this.message = message;
        }
        public string getMessage()
        {
            return message;
        }
    }
}
