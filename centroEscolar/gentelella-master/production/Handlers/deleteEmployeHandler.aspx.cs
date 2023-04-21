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
    public partial class deleteEmployeHandler : System.Web.UI.Page
    {
        private EmployeService employeService=new EmployeService();
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            bool banUserSessionClose = false;
            bool banUserBroked = false;            
            validateUserStatus.validateStatusUserLoggeIn(requestDelete, ref banUserBroked, ref banUserSessionClose);
            if (banUserBroked)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionClose(MessagesErrors.accountLockedAndLoggedOut);
            }
            else if (banUserSessionClose)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionClose(MessagesErrors.closedSession);
            }
        }
        private void requestDelete()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string strIds = Request.QueryString["idsToDelete"];
            string strTypeWorker = Request.QueryString["typeWorker"];
            var userLoggedIn = (User)Session["user"];
            try
            {
                var success = employeService.deleteEmployes(strTypeWorker, strIds, userLoggedIn);
                if (success)
                {
                    response.success = success;
                    string table = employeService.buildTableEmployeByTypeWorker(strTypeWorker);                    
                    data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));                    
                }
                else
                {
                    response.error = "No se ha podido eliminar.";
                }
            }
            catch (ServiceException e)
            {
                response.error = e.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}