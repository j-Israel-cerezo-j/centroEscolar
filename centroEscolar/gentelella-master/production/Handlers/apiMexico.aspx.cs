using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using Entidades;
using Newtonsoft.Json;
namespace centroEscolar.gentelella_master.production.Handlers
{
    public partial class apiMexico : System.Web.UI.Page
    {
       

        private ApiMexico apMexico = new ApiMexico();
        public string getJsonResponse { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            recoverData();

        }
        private void recoverData()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.QueryString["catalogo"];
            string value = Request.QueryString["value"];
            if (catalogo != ""&& value != "")
            {
                try
                {
                    var json = apMexico.recoverDatas(catalogo,value);
                    if (json != "")
                    {
                        response.success = true;                        
                        data.Add(catalogo, JsonConvert.DeserializeObject<string[]>(json));                        
                    }
                    else
                    {
                        response.error = "Sin resultados";
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
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}