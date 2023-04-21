using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio.binderSurvey.Services;
using CapaLogicaNegocio.Services;

namespace centroEscolar.gentelella_master.production.binderSurvey
{
    public partial class graphics : System.Web.UI.Page
    {
        public string getStrFormantGraphycChartByCategorys { get; set; }
        public string getStrFormantGraphycChartByUniversitys { get; set; }
        private GraphicsService graphicsService = new GraphicsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Encuestador"] != null || Session["Administradorr"] != null)
            {
                buildFormantGraphycChartByCategorys();
                buildFormantGraphycChartByUniversitys();
            }
            else
            {
                Response.Redirect("../index.aspx");
            }           
        }
        private void buildFormantGraphycChartByCategorys()
        {
            getStrFormantGraphycChartByCategorys = graphicsService.byCategorys();
        }

        private void buildFormantGraphycChartByUniversitys()
        {
            getStrFormantGraphycChartByUniversitys = graphicsService.byUniversidades();
        }
    }
}