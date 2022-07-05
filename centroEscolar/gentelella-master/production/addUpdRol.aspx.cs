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
        protected void Page_Load(object sender, EventArgs e)
        {
            jsonRoles();
        }
        private void jsonRoles()
        {
            getJsonRoles=logicaRol.jsonRoles();
        }
    }
}