using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.updates
{
    public class UpdateEmploye
    {
        private DatosEmploye datos = new DatosEmploye();
        public bool update(User empelado)
        {
            bool ban = false;
            switch (empelado)
            {
                case LocalEmploye employeL:
                    ban = datos.updateEmployLocal(employeL);
                    break;
                case GeneralEmploye employeG:
                    ban = datos.updateEmployGeneral(employeG);
                    break;
            }
            return ban;
        }
    }
}
