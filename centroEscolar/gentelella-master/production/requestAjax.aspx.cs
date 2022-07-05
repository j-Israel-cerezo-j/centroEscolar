using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using Entidades;
using Newtonsoft.Json;
namespace centroEscolar.gentelella_master.production
{
    public partial class requestAjax : System.Web.UI.Page
    {
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        private FacadeRequestAjax facadeRequestAjax = new FacadeRequestAjax();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["add"] != null)
            {
                requestAdd();
            }
        }
        private void requestAdd()
        {
            
            List<string> msjErrors = new List<string>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string submit = Request.Form.ToString();
            if (submit != "" && catalogo != "")
            {
                try
                {
                    var success = facadeRequestAjax.ajaxRequestCatalogos(catalogo, submit);
                    if (success)
                    {
                        response.success = success;                       
                    }
                    else
                    {                        ;                       
                        msjErrors.Add("No se ha podido agregar.");
                        response.error = msjErrors;                        
                    }
                }
                catch (Exception e)
                {
                    msjErrors.Add("El nombre de reserva no fue encontrado.");
                    response.error = msjErrors;
                }
            }
            else
            {
                msjErrors.Add("Campos vacios");
                response.success = false;
                response.error = msjErrors;
            }
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}