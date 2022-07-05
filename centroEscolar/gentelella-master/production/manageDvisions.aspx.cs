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
    public partial class manageDvisions : System.Web.UI.Page
    {
        public List<Carrer> getCarrers { get; set; }
        private DivisionService divisionSer = new DivisionService();        
        protected void Page_Load(object sender, EventArgs e)
        {
            listCarrers();            
        }
        private void listCarrers()
        {
            getCarrers = divisionSer.listarCarrers();
        }       
    }
}