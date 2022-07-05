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
namespace centroEscolar.gentelella_master.production
{    
    public partial class submitHandlerCatalogos : System.Web.UI.Page
    {
        private FacadeRecoverData facadeRecoverData = new FacadeRecoverData();
        private FacadeRequestAjax facadeRequestAjax = new FacadeRequestAjax();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.Form["typeSubmit"];
            if (type=="add")
            {
                requestAdd();
            }else if (type == "recoverData")
            {
                recoverData();
            }
            else if (type == "delete")
            {
                requestDelete();
            }else if (type == "update")
            {
                requestUpdate();
            }
        }
        private void requestAdd()
        {            
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string[] submit = Request.Form.AllKeys;
            var valuesSubmit = getValuesForm(submit);
            if (submit.Length>0 && catalogo != "")
            {
                try
                {
                    var success = facadeRequestAjax.ajaxRequestCatalogos(catalogo, valuesSubmit);
                    if (success)
                    {
                        response.success = success;
                        string table= facadeRequestAjax.ajaxRequestCatalogosTable(catalogo);
                        var data = new Dictionary<string, Object>();
                        data.Add("info", catalogo);
                        data.Add("type", "add");
                        data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));
                        response.data = data;
                    }
                    else
                    {
                        response.error = "¡Error inesperado en el servidor!.";                        
                    }
                }
                catch (ServiceException ex)
                {                    
                    response.error=ex.getMessage();
                }
            }
            else
            {                
                response.error = "Campos vacios";
                response.success = false;                
            }
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void recoverData()
        {                      
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string id = Request.QueryString["id"];            
            if (catalogo != "" && id!="")
            {
                try
                {
                    var json = facadeRecoverData.recoverData(catalogo,id);
                    if (json!="")
                    {
                        response.success = true;                        
                        var data = new Dictionary<string, Object>();
                        data.Add("info", catalogo);
                        data.Add("recoverDates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                        response.data = data;
                    }
                    else
                    {
                        response.error="No se ha podido agregar.";                        
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
        private void requestUpdate()
        {            
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string strId = Request.Form["id"];
            string[] submit = Request.Form.AllKeys;
            var valuesSubmit = getValuesForm(submit);
            if (strId!="" && catalogo != "" && valuesSubmit.Count>0)
            {
                try
                {
                    var success = facadeRequestAjax.ajaxRequestUpdate(catalogo, valuesSubmit, strId);
                    if (success)
                    {
                        response.success = success;
                        string table = facadeRequestAjax.ajaxRequestCatalogosTable(catalogo);
                        var data = new Dictionary<string, Object>();
                        data.Add("info", catalogo);
                        data.Add("type", "update");
                        data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));
                        response.data = data;
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
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void requestDelete()
        {            
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string strIds = Request.Form["idsToDelete"];
            if (strIds !="" && catalogo != "")
            {
                try
                {
                    var success = facadeRequestAjax.ajaxRequestDelete(catalogo, strIds);
                    if (success)
                    {
                        response.success = success;
                        string table = facadeRequestAjax.ajaxRequestCatalogosTable(catalogo);
                        var data = new Dictionary<string, Object>();
                        data.Add("info", catalogo);
                        data.Add("type", "delete");
                        data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));
                        response.data = data;
                    }
                    else
                    {
                        response.error = "No se ha podido eliminar.";                        
                    }
                }
                catch (Exception e)
                {
                    response.error = "¡Error inesperado en el servidor!";                    
                }
            }           
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private Dictionary<string, string> getValuesForm(string[] submitKeys)
        {
            var values = new Dictionary<string, string>();
            for (int i = 0; i < submitKeys.Length; i++)
            {
                string value=Request.Form[submitKeys[i]];
                values.Add(submitKeys[i], value);
            }
            return values;  
        }
    }
}