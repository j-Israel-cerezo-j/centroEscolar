using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.binderSurvey;
using CapaLogicaNegocio.binderSurvey.Services.fomantGraphycChart;
namespace CapaLogicaNegocio.binderSurvey.Services
{
    public class GraphicsService
    {
        private FomantGraphycChart fomantGraphycChart = new FomantGraphycChart();
        public string byCategorys()
        {
            return fomantGraphycChart.ByCategorys();
        }
        public string byUniversidades()
        {
            return fomantGraphycChart.ByUniversity();
        }

    }
}
