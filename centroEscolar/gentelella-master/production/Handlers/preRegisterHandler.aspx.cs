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
namespace centroEscolar.gentelella_master.production.Handlers
{
    public partial class preRegisterHandler : System.Web.UI.Page
    {
        private StudentCandidateService studentCandidateService = new StudentCandidateService();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            requestAdd();
        }
        private void requestAdd()
        {            
            Response response = new Response();
            var data = new Dictionary<string, object>();
            string[] submit = Request.Form.AllKeys;
            var valuesSubmit = getValuesForm(submit);
            if (submit.Length > 0)
            {
                try
                {
                    var newCandidateStudent = studentCandidateService.addCandidateStudentToStudents(valuesSubmit);
                    if (newCandidateStudent!=null)
                    {                        
                        response.success = true;
                        var jsonDatasCandidate = studentCandidateService.candidateData_EMAILINS_PASSWORD_MATRICULA(newCandidateStudent);
                        data.Add("info",JsonConvert.DeserializeObject<Dictionary<string, Object>> (jsonDatasCandidate));
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