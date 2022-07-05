using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using CapaLogicaNegocio;
using Newtonsoft.Json;
namespace centroEscolar.gentelella_master.production.Handlers
{
    public partial class handlerRequestDivisionsXCarrer : System.Web.UI.Page
    {
        public string getJsonResponse { get; set; }
        private DivisionService divisionService = new DivisionService();
        protected void Page_Load(object sender, EventArgs e)
        {
            recoverData();
        }
        private void recoverData()
        {            
            Response response = new Response();            
            string strId = Request.QueryString["id"];
            if (strId != "")
            {
                try
                {
                    var json = divisionService.divisionsXcarrer(strId);
                    if (json != "")
                    {
                        response.success = true;
                        var data = new Dictionary<string, Object>();                        
                        data.Add("recoverDates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                        response.data = data;
                    }
                    else
                    {
                        response.error = "No se ha podido agregar.";                        
                    }
                }
                catch (Exception e)
                {
                    response.error = "¡Error inesperado en el servidor!";                    
                }
            }
            else
            {
                response.error = "Campos vacios";
                response.success = false;                
            }
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}