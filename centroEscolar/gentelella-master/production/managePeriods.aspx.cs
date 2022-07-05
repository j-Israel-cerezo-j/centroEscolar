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
    public partial class managePeriods : System.Web.UI.Page
    {
        private PeriodService servicePeriods = new PeriodService();
        public string getJsonPeriods { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            jsonPeriods();
        }
        private void jsonPeriods()
        {
            getJsonPeriods = servicePeriods.jsonPeriods();
        }
    }
}