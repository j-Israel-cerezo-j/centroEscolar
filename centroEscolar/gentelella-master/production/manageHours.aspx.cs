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
    public partial class manageHours : System.Web.UI.Page
    {
        private HoursService hoursService = new HoursService();
        public string getJsonHours { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            jsonHours();
        }
        private void jsonHours()
        {
            getJsonHours = hoursService.jsonHours();
        }
    }
}