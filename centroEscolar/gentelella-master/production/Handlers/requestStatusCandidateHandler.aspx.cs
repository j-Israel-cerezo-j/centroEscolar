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
    public partial class requestStatusCandidateHandler : System.Web.UI.Page
    {
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
        private StudentCandidateService studentCandidateS = new StudentCandidateService();
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
            try
            {
                var jsonStatusCandidates = studentCandidateS.jsonStatusCandidate();
                if (jsonStatusCandidates!="")
                {                                                
                    response.success = true;                    
                    data.Add("jsonStatusCandidates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonStatusCandidates));                    
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
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}