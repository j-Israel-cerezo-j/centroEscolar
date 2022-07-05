using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
namespace centroEscolar.gentelella_master.production
{
    public partial class manageStudent : System.Web.UI.Page
    {
        private StudentService studentService= new StudentService();
        public string getJsonStudents { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            jsonStudents();
        }
        private void jsonStudents()
        {
            getJsonStudents = studentService.jsonStudents();
        }
    }
}