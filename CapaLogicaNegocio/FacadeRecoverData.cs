using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public  class FacadeRecoverData
    {
        private LogicaRol logicaRol = new LogicaRol();
        private StudentService studentService = new StudentService();
        private GroupService groupService = new GroupService();
        private CarrersService carrersService = new CarrersService();
        private LevelService levelService = new LevelService();
        private PeriodService periodService = new PeriodService();
        private SubjectService subjectService = new SubjectService();
        private HoursService timesService= new HoursService();
        private DivisionService divService = new DivisionService();
        public string recoverData(string catalogo, string strId)
        {
            
            string json = "";
            switch (catalogo)
            {
                case "roles":
                    json = logicaRol.jsonRecoverData(strId);
                    break;
                case "alumnos":
                    json = studentService.jsonRecoverData(strId);
                    break;
                case "grupos":
                    json = groupService.jsonRecoverData(strId);
                    break;
                case "carreras":
                    json = carrersService.jsonRecoverData(strId);
                    break;
                case "cuatrimestres":
                    json = levelService.jsonRecoverData(strId);
                    break;
                case "periodos":
                    json = periodService.jsonRecoverData(strId);
                    break;
                case "materias":
                    json = subjectService.jsonRecoverData(strId);
                    break;
                case "horas":
                    json = timesService.jsonRecoverData(strId);
                    break;
                case "divisiones":
                    json = divService.jsonRecoverData(strId);
                    break;
            }
            return json;
        }
    }
}
