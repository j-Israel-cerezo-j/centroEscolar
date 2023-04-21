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
    public partial class requestTableEmployeByTypeWorkerHandler : System.Web.UI.Page
    {
        private EmployeService employeService = new EmployeService();
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
            string strTypeWorker = Request.QueryString["typeWorker"];
            if (strTypeWorker != "")
            {
                try
                {
                    var json = employeService.buildTableEmployeByTypeWorker(strTypeWorker);
                    if (json != "")
                    {
                        var jsonStatusEmployes= employeService.jsonStatusuUsers();
                        response.success = true;
                        data.Add("recoverTable", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                        data.Add("jsonStatusEmployes", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonStatusEmployes));
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