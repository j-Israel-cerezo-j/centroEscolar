using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using CapaLogicaNegocio.utils;

namespace centroEscolar.gentelella_master.production
{
    public partial class manageStudent : System.Web.UI.Page
    {
        private StudentService studentService= new StudentService();
        public string getJsonStudents { get; set; }
        public string getJsonStates { get; set; }
        public string getJsonStatusUsers { get; set; }
        public bool getExistingRecords { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                jsonStudents();
                jsonStatesMexico();
                existingRecords();
                jsonStatusUsers();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }
           
        }
        private void jsonStudents()
        {
            getJsonStudents = studentService.jsonStudents();
        }
        private void existingRecords()
        {
            getExistingRecords = !(studentService.jsonStudents() == "[]");
        }
        private void jsonStatesMexico()
        {
            getJsonStates = JsonMexico.States();
        }
        private void jsonStatusUsers()
        {
            getJsonStatusUsers=studentService.jsonStatusuUsers();
        }
    }
}