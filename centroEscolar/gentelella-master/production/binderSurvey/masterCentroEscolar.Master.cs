using CapaLogicaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centroEscolar.gentelella_master.production.binderSurvey
{
    public partial class masterCentroEscolar : System.Web.UI.MasterPage
    {
        public List<string> getPermisosList { get; set; }
        private UserService userService = new UserService();
        public string getPermisos { get; set; }
        public User getUserLogin { get; set; }
        private const string pathLogin= "../Login.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect(pathLogin);
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
                        Response.Redirect(pathLogin);
                    }
                    else
                    {
                        getPermisos = userService.permisosUsuarioLogueado(userLogin);
                        getUserLogin = userLogin;
                    }
                }
            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect(pathLogin);
        }
    }
}