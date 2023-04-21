using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using Entidades;
using CapaLogicaNegocio.utils;
namespace centroEscolar.gentelella_master.production
{
    public partial class preRegisterStudent : System.Web.UI.Page
    {
        public List<Carrer> getCarrers { get; set; }
        private DivisionService divisionSer = new DivisionService();
        public string getJsonDivisions { get; set; }
        public string getJsonStates { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            listCarrers();
            jsonDivisions();
            jsonStatesMexico();
        }
        private void listCarrers()
        {
            getCarrers = divisionSer.listarCarrers();
        }
        private void jsonDivisions()
        {
            getJsonDivisions = divisionSer.jsonDivisions();
        }
        private void jsonStatesMexico()
        {
            getJsonStates= JsonMexico.States();
        }
    }
}