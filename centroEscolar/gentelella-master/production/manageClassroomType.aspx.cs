using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
namespace centroEscolar.gentelella_master.production
{
    public partial class manageClassroomType : System.Web.UI.Page
    {
        private TypeClassroomService typeClassroom = new TypeClassroomService();
        public string getJsonTypeClassrooms { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                jsonTypeClassrooms();
            }
            else
            {
                Response.Redirect("indexUser.aspx");
            }
           
        }
        private void jsonTypeClassrooms()
        {
            getJsonTypeClassrooms = typeClassroom.jsonTypeClassrooms();
        }
    }
}