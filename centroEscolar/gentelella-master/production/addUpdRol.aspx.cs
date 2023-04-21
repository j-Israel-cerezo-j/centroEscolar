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
    public partial class addUpdRol : System.Web.UI.Page
    {
        private LogicaRol logicaRol = new LogicaRol();
        public string getJsonRoles { get; set; }
        public List<TypeWorker> getTypesWorkers { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                jsonRoles();
                listTypesWorkers();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }
        }
        private void jsonRoles()
        {
            getJsonRoles=logicaRol.jsonRoles();
        }
        private void listTypesWorkers()
        {
            getTypesWorkers = logicaRol.listTypesWorker();
        }
    }
}