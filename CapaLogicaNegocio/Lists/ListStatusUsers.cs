using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaLogicaNegocio.Lists
{
    public class ListStatusUsers
    {
        private DatosStatusUsers datos = new DatosStatusUsers();

        public List<StatusUser> listarStatusUsers()
        {
            return datos.listarStatus();
        }
    }
}
