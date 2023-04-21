using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.Exceptions;
namespace CapaLogicaNegocio.Facades
{
    public class FacadeStatusUser
    {
        private StudentService studentService = new StudentService();
        private EmployeService employeService = new EmployeService();
        public bool updateStatusUsers(string user, string fkStatus,string idUser, User userLoggedIn,string typeWorker="")
        {

            bool succes = false;
            switch (user)
            {
               
                case "alumnos":
                    succes = studentService.updateStatus(fkStatus, idUser);
                    break;
                case "trabajadores":
                    succes = employeService.updateStatus(fkStatus, idUser, typeWorker, userLoggedIn);
                    break;
                default:
                    throw new ServiceException("Parametro no valido");
            }
            return succes;
        }
        public string recoverDatasStatusUsers(string user)
        {

            string jsonStatus = "";
            switch (user)
            {

                case "alumnos":
                    jsonStatus = studentService.jsonStatusuUsers();
                    break;
                case "trabajadores":
                    jsonStatus = employeService.jsonStatusuUsers();
                    break;
                default:
                    throw new ServiceException("Parametro no valido");
            }
            return jsonStatus;
        }
    }
}
