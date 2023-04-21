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
    public partial class manageClassrooms : System.Web.UI.Page
    {
        public List<Building> getBuildings { get; set; }
        public List<TypeClassroom> getTypeClassrooms { get; set; }
        private ClassroomService classroomService = new ClassroomService();
        public string getJsonClassrooms { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                listgetBuildings();
                jsonTypeClassrooms();
                jsonClassrooms();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }
          
        }
        private void listgetBuildings()
        {
            getBuildings = classroomService.listarBuildings();
        }
        private void jsonTypeClassrooms()
        {
            getTypeClassrooms = classroomService.listarTypeClassroom();
        }
        private void jsonClassrooms()
        {
            getJsonClassrooms = classroomService.jsonClasrooms();
        }
    }
}