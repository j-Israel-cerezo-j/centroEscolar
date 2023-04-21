using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Exceptions;
using centroEscolar.gentelella_master.production.messagesErrors;
using Entidades;
using Newtonsoft.Json;
namespace centroEscolar.gentelella_master.production.Handlers
{
    public partial class rolesByTypeWorkerHandler : System.Web.UI.Page
    {
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
        private TypeWorkerService tpWorkerService = new TypeWorkerService();
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
            string strIdTypeWorker = Request.QueryString["typeWorjerID"];
            string catalogo = Request.QueryString["catalogo"];
            if (strIdTypeWorker != ""&& catalogo!="")
            {
                try
                {
                    var json = tpWorkerService.jsonRolesBytypeWorker(strIdTypeWorker);
                    response.success = true;
                    data.Add("catalogo", catalogo);
                    data.Add("rolesByTypeWorker", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));                    
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