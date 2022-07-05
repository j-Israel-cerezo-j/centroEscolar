using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
namespace centroEscolar.gentelella_master.production
{
    public partial class manageAcademicLevel : System.Web.UI.Page
    {
        private LevelService levelService = new LevelService();
        public string getJsonLevels { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            jsonLevels();
        }
        private void jsonLevels()
        {
            getJsonLevels = levelService.jsonLevels();
        }
    }
}