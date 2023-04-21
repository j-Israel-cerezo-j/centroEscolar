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

namespace centroEscolar.gentelella_master.production.Handlers.handlersTables
{
    public partial class tableBuildingsHandler : System.Web.UI.Page
    {
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
        private FacadeRequestAjax facadeRequestAjax = new FacadeRequestAjax();
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
            Response response = new Response();
            string catalogue = Request.Form["catalogo"];
            if (catalogue != "")
            {
                try
                {
                    var json = facadeRequestAjax.ajaxRequestCatalogosTable(catalogue);
                    if (json != "")
                    {
                        response.success = true;
                        var data = new Dictionary<string, Object>();
                        data.Add("recoverTable", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                        response.data = data;
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
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}