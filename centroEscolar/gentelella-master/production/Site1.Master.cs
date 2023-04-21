using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using Entidades;
namespace centroEscolar.gentelella_master.production
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private UserService userService = new UserService();
        public string getStrPermisos { get; set; }
        public List<string> getPermisosDictionary { get; set; }
        public User getUserLogin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                validateStatusSession();
            }
        }
        protected void validateStatusSession()
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
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        getStrPermisos = userService.permisosUsuarioLogueado(userLogin);
                        getUserLogin = userLogin;
                    }
                }
            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}