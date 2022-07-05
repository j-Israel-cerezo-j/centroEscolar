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
    public partial class manageGroups : System.Web.UI.Page
    {
        private GroupService serviceGroups = new GroupService();
        public string getJsonGroups { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            jsonRoles();
        }
        private void jsonRoles()
        {
            getJsonGroups = serviceGroups.jsonGroups();
        }
    }
}