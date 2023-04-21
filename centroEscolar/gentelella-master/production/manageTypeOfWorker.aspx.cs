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
    public partial class manageTypeOfWorker : System.Web.UI.Page
    {
        private TypeWorkerService typesWorkersService = new TypeWorkerService();
        public string getJsonTypesWorkers { get; set; }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                jsonTypesWorkers();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }            
        }
        private void jsonTypesWorkers()
        {
            getJsonTypesWorkers = typesWorkersService.jsonTypesWorkers();
        }
        
    }
}