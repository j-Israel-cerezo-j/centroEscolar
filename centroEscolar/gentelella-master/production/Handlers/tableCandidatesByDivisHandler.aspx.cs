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
    public partial class tableCandidatesByDivisHandler : System.Web.UI.Page
    {
        private StudentCandidateService studentCandidateService = new StudentCandidateService();
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
            string strId = Request.QueryString["id"];
            if (strId != "")
            {
                try
                {
                    var json = studentCandidateService.jsonCandidatesByIDdiv(strId);
                    if (json != "")
                    {
                        var jsonStatusCandidates = studentCandidateService.jsonStatusCandidate();
                        response.success = true;                        
                        data.Add("recoverDates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                        data.Add("jsonStatusCandidates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonStatusCandidates));
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