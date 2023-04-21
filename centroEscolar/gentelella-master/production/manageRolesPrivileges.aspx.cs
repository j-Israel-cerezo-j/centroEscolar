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
    public partial class manageRolesPrivileges : System.Web.UI.Page
    {
        private RolePrivilegesService rolePrivileges = new RolePrivilegesService();
        public string getJsonPrivilegesRoles { get; set; }
        public List<Rol> getRoles { get; set; }
        public List<Privilege> getPrivileges { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                listRoles();
                listPrivileges();
                jsonRolesPrivileges();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }
           
        }
        private void jsonRolesPrivileges()
        {
            getJsonPrivilegesRoles = rolePrivileges.jsonrolesPrivileges();
        }
        private void listRoles()
        {
            getRoles = rolePrivileges.listRoles();
        }
        private void listPrivileges()
        {
            getPrivileges = rolePrivileges.lisstPrivileges();
        }
    }
}