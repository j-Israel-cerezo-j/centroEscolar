using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogicaNegocio.tablesInner
{
    public class TableClassrom
    {
        private DatosClassroom datos = new DatosClassroom();
        public DataTable tableClassroomsBymatchingCharacters(string characters)
        {
            return datos.tableClassroomsByMatchingCharacterss(characters);
        }
        public DataTable tableClassrooms()
        {
            return datos.tableClassrooms();
        }
        public DataTable tableClassroomsByTypeClassroom(int id)
        {
            return datos.tableClassroomsByTypeClassroom(id);
        }
        public DataTable tableClassroomsByEdif(int id)
        {
            return datos.tableClassroomsByEdif(id);
        }
        public DataTable tableClassroomsByCarrers(int id)
        {
            return datos.tableClassroomsByCarrers(id);
        }
    }
}
