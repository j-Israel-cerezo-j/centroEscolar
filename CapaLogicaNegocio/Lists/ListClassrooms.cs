using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListClassrooms
    {
        private DatosClassroom datos = new DatosClassroom();
        public List<Classroom> listarClassrooms()
        {
            return datos.listarClassrooms();
        }
        public List<Classroom> listarClasrromsXedif(int id)
        {
            return datos.listarClassroomsXFkEdificio(id);
        }
        public List<Classroom> listarClasrromsXTypeClassroom(int id)
        {
            return datos.listarClassroomsXFkTipoSalon(id);
        }
    }
}
