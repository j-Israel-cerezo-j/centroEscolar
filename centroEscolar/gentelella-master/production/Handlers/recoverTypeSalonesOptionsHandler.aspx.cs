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
    public partial class recoverTypeSalonesOptionsHandler : System.Web.UI.Page
    {
        private ClassroomService classroomService = new ClassroomService();
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
            string strTypeClassroomOptions = Request.QueryString["typeClassroomOptions"];
            if (strTypeClassroomOptions != "")
            {
                try
                {
                    var json = classroomService.typeClassroomOptions(strTypeClassroomOptions);
                    if (json != "")
                    {
                        response.success = true;                        
                        data.Add("recoverDates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));                        
                    }
                    else
                    {
                        response.error = "¡Error inesperado en el servidor!.";
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