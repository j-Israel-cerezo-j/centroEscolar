using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Exceptions
{
    public class LoginException : Exception
    {
        private string message;
        public LoginException(string message)
        {
            this.message = message;
        }
        public string getMessage()
        {
            return message;
        }
    }
}
