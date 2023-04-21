using CapaLogicaNegocio.Facades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Facades;
using CapaLogicaNegocio.Exceptions;
using Entidades;
using Newtonsoft.Json;
using CapaLogicaNegocio.updates;
using centroEscolar.gentelella_master.production.messagesErrors;

namespace centroEscolar.gentelella_master.production.Handlers
{
    public partial class requestDataStatusUserHandler : System.Web.UI.Page
    {
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        private FacadeStatusUser statusUser = new FacadeStatusUser();
        private FacadeRequestAjax facadeRequest = new FacadeRequestAjax();
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
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
            string strUser = Request.QueryString["User"];
            try
            {
                if (strUser != "")
                {
                    var jsonStatusCandidates = statusUser.recoverDatasStatusUsers(strUser);
                    if (jsonStatusCandidates != "")
                    {
                        response.success = true;
                        data.Add("jsonStatusUsers", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonStatusCandidates));
                    }
                    else
                    {
                        response.error = "Error en el servidor.";
                    }
                }
                else
                {
                    response.error = "Parametro no valido";
                }
                
            }
            catch (ServiceException ex)
            {
                response.error = ex.getMessage();
            }           
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}