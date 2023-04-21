using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using Entidades;
namespace centroEscolar.gentelella_master.production
{
    public partial class manageStudentsCandidates : System.Web.UI.Page
    {
        private StudentCandidateService studentService = new StudentCandidateService();
        public List<Carrer> getCarrers { get; set; }      
        private DivisionService divisionSer = new DivisionService();
        public string getStatusCandidates { get; set; }
        public string getJsonStudents { get; set; }
        public bool getExistingRecords { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                jsonStudents();
                listCarrers();
                listStatusCandidates();
                existingRecords();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }           
        }
        private void listStatusCandidates()
        {
            getStatusCandidates= studentService.jsonStatusCandidate();
        }
        private void jsonStudents()
        {
            getJsonStudents = studentService.jsonCandidates().ToString();
        }
        private void listCarrers()
        {
            getCarrers = divisionSer.listarCarrers();
        }
        private void existingRecords()
        {
            getExistingRecords = !(studentService.jsonCandidates().ToString() == "[]");
        }
    }
}