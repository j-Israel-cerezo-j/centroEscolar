using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
namespace centroEscolar.gentelella_master.production
{
    public partial class manageSubjects : System.Web.UI.Page
    {
        private SubjectService subjectService = new SubjectService();
        public string getJsonSubjects { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            jsonSubjects();
        }
        private void jsonSubjects()
        {
            getJsonSubjects = subjectService.jsonSubjects();
        }
    }
}