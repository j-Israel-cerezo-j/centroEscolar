using CapaLogicaNegocio.Services;
using centroEscolar.gentelella_master.production.messagesErrors;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centroEscolar.gentelella_master.production.Handlers.binderSurvey
{
    public partial class questionAnswersHandler : System.Web.UI.Page
    {
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
        public static string getJsonResponse { get; private set; } = "{\"k\":1}";
        private SurveysService surveysService = new SurveysService();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool banUserSessionClose = false;
            bool banUserBroked = false;
            validateUserStatus.validateStatusUserLoggeIn(questionsAnswer, ref banUserBroked, ref banUserSessionClose);
            if (banUserBroked)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionCloseSurbey(MessagesErrors.accountLockedAndLoggedOut);
            }
            else if (banUserSessionClose)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionCloseSurbey(MessagesErrors.closedSession);
            }
            
        }
        private void questionsAnswer()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string strIdQuestion = Request.QueryString["idQuestions"];
            try
            {
                var jsonResponses = surveysService.jsonQuestionsAnswer(strIdQuestion);
                if (jsonResponses != "")
                {
                    response.success = true;
                    data.Add("questionsAnswer", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonResponses));
                }
            }
            catch (Exception e)
            {
                response.error = "Error";
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}