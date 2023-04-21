using CapaLogicaNegocio;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio.binderSurvey.Services;
using CapaLogicaNegocio.Services;
using centroEscolar.gentelella_master.production.messagesErrors;
namespace centroEscolar.gentelella_master.production.binderSurvey.Handlers
{
    public partial class questionsByCategorusHandler : System.Web.UI.Page
    {
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
        public string getJsonResponse { get; set; }
        private QuestionsService questionsService = new QuestionsService();
        protected void Page_Load(object sender, EventArgs e)
        {

            bool banUserBroked = false;
            bool banUserSessionClose = false;
            validateUserStatus.validateStatusUserLoggeIn(recoverData, ref banUserBroked, ref banUserSessionClose);
            if (banUserBroked)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionCloseSurbey(MessagesErrors.accountLockedAndLoggedOut);
            }
            else if (banUserSessionClose)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionCloseSurbey(MessagesErrors.closedSession);
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
                    var json = questionsService.questionsByCategorys(strId);
                    if (json != "")
                    {
                        response.success = true;
                        data.Add("recoverDates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                    }
                    else
                    {
                        response.error = "No se ha podido agregar.";
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