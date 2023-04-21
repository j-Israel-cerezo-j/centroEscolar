using CapaLogicaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaLogicaNegocio;
using CapaLogicaNegocio.deletes;
using WebGrease.Css.Ast.Selectors;
using Entidades;
using Newtonsoft.Json;
namespace centroEscolar.gentelella_master.production
{
    public class ValidateUserStatus : System.Web.UI.Page
    {
        public delegate void functionToExecute();

        private UserService userService = new UserService();
        public void validateStatusUserLoggeIn(functionToExecute callback,ref bool banUserBroked, ref bool banUserSessionClose)
        {
            User userLogin = (User)Session["user"];
            if (userLogin != null)
            {
                var statusUserLoggeIn = userService.findStatusUser(userLogin);
                if (statusUserLoggeIn != null)
                {
                    if (statusUserLoggeIn.fkStatusUser == "bloqueado")
                    {
                        Session.Clear();
                        Session.Abandon();
                        banUserBroked=true;
                        
                    }
                    else
                    {
                        callback();
                    }
                }                
            }
            else
            {
                banUserSessionClose = true;
            }
        }

        public string messageJsonErrorUserBrokedSessionClose(string msjError)
        {
            Response response = new Response();
            var data = new Dictionary<string, object>();
            data.Add("footeer", "<a href='Login.aspx'>Ir a Login</a>");
            response.data = data;
            response.error = msjError;
            return JsonConvert.SerializeObject(response);
        }


        public string messageJsonErrorUserBrokedSessionCloseSurbey(string msjError)
        {
            Response response = new Response();
            var data = new Dictionary<string, object>();
            data.Add("footeer", "<a href='../Login.aspx'>Ir a Login</a>");
            response.data = data;
            response.error = msjError;
            return JsonConvert.SerializeObject(response);
        }
    }
}