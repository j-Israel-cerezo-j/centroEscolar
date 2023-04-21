using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio;
using centroEscolar.gentelella_master.production.messagesErrors;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio.binderSurvey;
namespace centroEscolar.gentelella_master.production.binderSurvey.Handlers
{
    public partial class onkeyupSearchCatalogosHandler : System.Web.UI.Page
    {
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
        private FacadeOnkeyupCatalogues facadeOnkeyupCatalogues = new FacadeOnkeyupCatalogues();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool banUserSessionClose = false;
            bool banUserBroked = false;
            validateUserStatus.validateStatusUserLoggeIn(onkeyupSearch, ref banUserBroked, ref banUserSessionClose);
            if (banUserBroked)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionClose(MessagesErrors.accountLockedAndLoggedOut);
            }
            else if (banUserSessionClose)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionClose(MessagesErrors.closedSession);
            }

        }
        private void onkeyupSearch()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.QueryString["catalogo"];
            string caracteresDeBusqueda = Request.Form["onkeyupCoincidencias"];
            string[] submit = Request.Form.AllKeys;
            var request = getValuesForm(submit);

            if (catalogo != "")
            {
                try
                {
                    var coincidencias = facadeOnkeyupCatalogues.onkeypCatalogosFacade(catalogo, caracteresDeBusqueda);
                    data.Add("catalogo", catalogo);
                    if (coincidencias.Count > 0)
                    {
                        var jsonTable = facadeOnkeyupCatalogues.onkeypCatalogosFacadeTables(catalogo, caracteresDeBusqueda, request);
                        response.success = true;
                        data.Add("coincidencias", coincidencias);
                        if (jsonTable != "")
                        {
                            data.Add("table", JsonConvert.DeserializeObject(jsonTable));
                        }
                    }
                    else
                    {
                        data.Add("accion", "sinCoincidencias");
                        response.success = true;
                    }
                }
                catch (ServiceException e)
                {
                    response.error = e.getMessage();
                }
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private Dictionary<string, string> getValuesForm(string[] submitKeys)
        {
            var values = new Dictionary<string, string>();
            for (int i = 0; i < submitKeys.Length; i++)
            {
                string value = Request.Form[submitKeys[i]];
                values.Add(submitKeys[i], value);
            }
            return values;
        }
    }
}