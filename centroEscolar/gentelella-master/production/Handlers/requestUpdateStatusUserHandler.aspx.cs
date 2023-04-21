using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class requestUpdateStatusUserHandler : System.Web.UI.Page
    {        
        private FacadeStatusUser statusUser =new FacadeStatusUser();
        private FacadeRequestAjax facadeRequest = new FacadeRequestAjax();
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
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
            string strIdStatus = Request.QueryString["idStatus"];
            string strUser = Request.QueryString["User"];
            string strIdUser = Request.QueryString["idUser"];
            string strIdTypeWorker = Request.QueryString["typeWorker"];
            var userLoggedIn =(User) Session["user"];
            if (strIdStatus != "" && strIdUser != "")
            {
                try
                {
                    var success = statusUser.updateStatusUsers(strUser,strIdStatus, strIdUser, userLoggedIn, strIdTypeWorker);
                    if (success)
                    {
                        var table = facadeRequest.ajaxRequestCatalogosTable(strUser, strIdTypeWorker);
                        var jsonStatusCandidates = statusUser.recoverDatasStatusUsers(strUser);
                        response.success = success;                        
                        data.Add("jsonUsers", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));
                        data.Add("jsonStatusUsers", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonStatusCandidates));                        
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
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}