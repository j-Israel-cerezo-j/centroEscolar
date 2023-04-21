using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.MessageErrors;
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
        private TypeWorkerService typesWorkers = new TypeWorkerService();
        private BuildingsService buildingsService = new BuildingsService();
        private TypeClassroomService typeClassroomService = new TypeClassroomService();
        private ClassroomService classroomService = new ClassroomService();
        private RolePrivilegesService rolePrivileges = new RolePrivilegesService();
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
                case "edificios":
                    json = buildingsService.jsonRecoverData(strId);
                    break;
                case "typesWorkers":
                    json = typesWorkers.jsonRecoverData(strId);
                    break;
                case "tiposDeSalon":
                    json = typeClassroomService.jsonRecoverData(strId);
                    break;
                case "salones":
                    json = classroomService.jsonRecoverData(strId);
                    break;
                case "privilegiosRoles":
                    json = rolePrivileges.jsonRecoverData(strId);
                    break;
            }
            return json;
        }
    }
}
