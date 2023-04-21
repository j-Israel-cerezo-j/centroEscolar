using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.validateDuplicateField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.util;

namespace CapaLogicaNegocio.utils
{
    public class Validate
    {
        public static void TypeWorker(string strFkTypeWorker)
        {
            if (strFkTypeWorker == ""||strFkTypeWorker==null)
            {
                throw new ServiceException(MessageError.radiusNotSelected);
            }
            else
            {
                if (!DuplicateField.duplicate("typeWorker", strFkTypeWorker, "tipoTrabajador"))
                {
                    throw new ServiceException(MessageError.nonexistentField(strFkTypeWorker));
                }
            }
        }
    }
}
