using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogicaNegocio.updates
{
    public class UpdateStatusUser
    {
        DatosStatusUsers datosStatusUsers = new DatosStatusUsers();
        public bool updateStatusUsers(string table, string fieldWhere, string strValueFieldSet, string fielSet, string fieldValueWhere)
        {
           return datosStatusUsers.updateStatusUser(table, fieldWhere, strValueFieldSet, fielSet, fieldValueWhere);
        }
    }
}
