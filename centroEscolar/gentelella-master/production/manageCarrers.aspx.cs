using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
namespace centroEscolar.gentelella_master.production
{
    public partial class manageCarrers : System.Web.UI.Page
    {
        private CarrersService serviceCarrers = new CarrersService();
        public string getJsonCarrers { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                jsonCarrers();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }
           
        }
        private void jsonCarrers()
        {
            getJsonCarrers = serviceCarrers.jsonCarrers();
        }
    }
}