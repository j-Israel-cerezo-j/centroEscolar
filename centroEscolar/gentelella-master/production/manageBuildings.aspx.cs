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
    public partial class manageBuildings : System.Web.UI.Page
    {
        private BuildingsService buildingsService=new BuildingsService();
        public List<Carrer> getCarrers { get; set; }
        public string getJsonBuildings { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                listCarrers();
                jsonDivision();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }
           
        }
        private void listCarrers()
        {
            getCarrers = buildingsService.listarCarrers();
        }
        private void jsonDivision()
        {
            getJsonBuildings = buildingsService.jsonBuildings();
        }
    }
}