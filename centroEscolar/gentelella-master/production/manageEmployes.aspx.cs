using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using CapaLogicaNegocio;
using CapaLogicaNegocio.utils;

namespace centroEscolar.gentelella_master.production
{
    public partial class manageEmployes : System.Web.UI.Page
    {
        private EmployeService employeService=new EmployeService();
        public List<TypeWorker> getTypesWorkers { get; set; }
        public List<Division> getDivisions { get; set; }
        public string getJsonStates { get; set; }
        public bool getExistingRecords { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                listDivisions();
                listTypesWorkers();
                jsonStatesMexico();
                existingRecords();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }
          
        }
        private void listTypesWorkers()
        {
            getTypesWorkers = employeService.listTypesWorker();
        }
        private void existingRecords()
        {
            getExistingRecords = employeService.existingRecordsFullEmployes();
        }
        private void listDivisions()
        {
            getDivisions = employeService.listDivisions();
        }
        private void jsonStatesMexico()
        {
            getJsonStates = JsonMexico.States();
        }
    }
}