using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.Session
{
    public class Sessions
    {
        private DatosUser datos = new DatosUser();
        public User login(string email)
        {
            return datos.login(email);
        }
        public User findStatusUserLoggeIn(int idUser)
        {
            return datos.findStatusUser(idUser);
        }
        public string rolUserLoggedIn(int idEmploye)
        {
            return datos.rolLoggedIn(idEmploye);
        }
    }
}
