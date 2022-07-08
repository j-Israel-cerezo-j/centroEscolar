using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Exceptions;
using Entidades;
using Newtonsoft.Json;
namespace centroEscolar.gentelella_master.production.Handlers
{
    public partial class manageStatusCandidatesAlumHandler : System.Web.UI.Page
    {
        private UserService userService = new UserService();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";

        protected void Page_Load(object sender, EventArgs e)
        {
            recoverData();
        }
        private void recoverData()
        {
            Response response = new Response();
            string strIdStatus = Request.QueryString["idStatus"];
            string strIdCandidate = Request.QueryString["idCandidate"];            
            if (strIdStatus != "" && strIdCandidate != "")
            {
                try
                {
                    var success = userService.manageStatusCandidate(strIdStatus, strIdCandidate);
                    if (success)
                    {
                        var table = userService.jsonCandidates();
                        var jsonStatusCandidates = userService.jsonStatusCandidate();
                        response.success = success;
                        var data = new Dictionary<string, Object>();
                        data.Add("jsonCandidates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));
                        data.Add("jsonStatusCandidates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonStatusCandidates));
                        response.data = data;
                    }
                    else
                    {
                        response.error = "Error en el servidor.";
                    }
                }
                catch (ServiceException ex)
                {
                    response.error = ex.getMessage();
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