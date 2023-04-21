using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.Adds
{
    public class AddEmploye
    {
        private DatosEmploye datos = new DatosEmploye();
        public int add(User empelado)
        {
            int idRecuperado = 0;
            switch (empelado)
            {
                case LocalEmploye employeL:
                    idRecuperado=datos.addEmployLocal(employeL);
                    break;
                case GeneralEmploye employeG:
                    idRecuperado = datos.addEmployGeneral(employeG);
                    break;
            }
            return idRecuperado;
        }
    }
}
