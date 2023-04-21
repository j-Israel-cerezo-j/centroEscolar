using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using Entidades;
using Newtonsoft.Json;
using CapaLogicaNegocio.Exceptions;
using centroEscolar.gentelella_master.production.messagesErrors;

namespace centroEscolar.gentelella_master.production.Handlers
{
    public partial class recoverDataEmployeHandler : System.Web.UI.Page
    {
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
        private EmployeService employeService = new EmployeService();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            bool banUserSessionClose = false;
            bool banUserBroked = false;
            validateUserStatus.validateStatusUserLoggeIn(recoverData, ref banUserBroked, ref banUserSessionClose);
            if (banUserBroked)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionClose(MessagesErrors.accountLockedAndLoggedOut);
            }
            else if (banUserSessionClose)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionClose(MessagesErrors.closedSession);
            }
        }        
        private void recoverData()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string strIdEmploye = Request.QueryString["idEmploye"];
            string strIdTypeWorker = Request.QueryString["idTypeWorker"];
            if (strIdEmploye != "" && strIdTypeWorker != "")
            {
                try
                {
                    var json = employeService.jsonRecoverDataEmployeById(strIdEmploye, strIdTypeWorker);
                    if (json != "")
                    {
                        response.success = true;                        
                        data.Add("info", catalogo);
                        data.Add("recoverDates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                        string jsonMunicpes = employeService.jsonMinicipesByStateEmploye(strIdEmploye, strIdTypeWorker);
                        data.Add("municipios", JsonConvert.DeserializeObject<string[]>(jsonMunicpes));                        
                    }
                    else
                    {
                        response.error = "¡Error inesperado en el servidor!.";
                    }
                }
                catch (ServiceException e)
                {
                    response.success = true;
                    response.error = e.getMessage();
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