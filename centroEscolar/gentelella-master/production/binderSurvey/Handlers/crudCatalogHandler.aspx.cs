using CapaLogicaNegocio;
using CapaLogicaNegocio.Exceptions;
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
    public partial class crudCatalogHandler : System.Web.UI.Page
    {
        private ValidateUserStatus validateUserStatus = new ValidateUserStatus();
        private FacadeCrudCatalogs crudCatalogs = new FacadeCrudCatalogs();
        public static string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            bool banUserBroked = false;
            bool banUserSessionClose = false;
            string type = Request.Form["typeSubmit"];
            if (type == "add")
            {
                validateUserStatus.validateStatusUserLoggeIn(requestAdd, ref banUserBroked, ref banUserSessionClose);

            }            
            else if (type == "delete")
            {
                validateUserStatus.validateStatusUserLoggeIn(requestDelete, ref banUserBroked, ref banUserSessionClose);
            }
            else if (type == "recoverData")
            {
                validateUserStatus.validateStatusUserLoggeIn(recoverData, ref banUserBroked, ref banUserSessionClose);
            }
            else if (type == "update")
            {
                validateUserStatus.validateStatusUserLoggeIn(requestUpdate, ref banUserBroked, ref banUserSessionClose);
            }
            if (banUserBroked)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionCloseSurbey(MessagesErrors.accountLockedAndLoggedOut);
            }
            else if (banUserSessionClose)
            {
                getJsonResponse = validateUserStatus.messageJsonErrorUserBrokedSessionCloseSurbey(MessagesErrors.closedSession);
            }
        }
        private void requestAdd()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string[] submit = Request.Form.AllKeys;
            var valuesSubmit = getValuesForm(submit);
            if (submit.Length > 0 && catalogo != "")
            {
                try
                {
                    var success = crudCatalogs.ajaxRequestCatalogosAdd(catalogo, valuesSubmit);
                    if (success)
                    {
                        response.success = success;
                        string table = crudCatalogs.ajaxRequestCatalogosTable(catalogo);
                        data.Add("info", catalogo);
                        data.Add("type", "add");
                        data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));

                    }
                    else
                    {
                        response.error = "¡Error inesperado en el servidor!.";
                    }
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
        private void requestDelete()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string strIds = Request.Form["idsToDelete"];
            if (strIds != "" && catalogo != "")
            {
                try
                {
                    var success = crudCatalogs.ajaxRequestDelete(catalogo, strIds);
                    if (success)
                    {
                        response.success = success;
                        string table = crudCatalogs.ajaxRequestCatalogosTable(catalogo);
                        data.Add("info", catalogo);
                        data.Add("type", "delete");
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
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void recoverData()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string id = Request.QueryString["id"];
            if (catalogo != "" && id != "")
            {
                try
                {
                    var json = crudCatalogs.recoverData(catalogo, id);
                    if (json != "")
                    {
                        response.success = true;
                        data.Add("info", catalogo);
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
        private void requestUpdate()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string strId = Request.Form["id"];
            string[] submit = Request.Form.AllKeys;
            var valuesSubmit = getValuesForm(submit);
            if (strId != "" && catalogo != "" && valuesSubmit.Count > 0)
            {
                try
                {
                    var success = crudCatalogs.ajaxRequestUpdate(catalogo, valuesSubmit, strId);
                    if (success)
                    {
                        response.success = success;
                        string table = crudCatalogs.ajaxRequestCatalogosTable(catalogo);
                        data.Add("info", catalogo);
                        data.Add("type", "update");
                        data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));
                    }
                    else
                    {
                        response.error = "¡Error inesperado en el servidor!.";
                    }
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