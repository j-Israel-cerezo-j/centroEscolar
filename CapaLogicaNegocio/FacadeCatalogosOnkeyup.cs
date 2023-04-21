using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class FacadeCatalogosOnkeyup
    {
        private LogicaRol logicaRol = new LogicaRol();
        private StudentService studentService = new StudentService();
        private GroupService groupService = new GroupService();
        private CarrersService carrersService = new CarrersService();
        private LevelService levelService = new LevelService();
        private PeriodService periodService = new PeriodService();
        private SubjectService SubjectService = new SubjectService();
        private HoursService timesService = new HoursService();
        private DivisionService divService = new DivisionService();
        private StudentCandidateService scService = new StudentCandidateService();
        private TypeWorkerService typesWorkers = new TypeWorkerService();
        private EmployeService employeService = new EmployeService();
        private BuildingsService buildingsService = new BuildingsService();
        private TypeClassroomService typeClassroomService = new TypeClassroomService();
        private ClassroomService classroomService = new ClassroomService();
        private RolePrivilegesService rolePrivileges = new RolePrivilegesService();
        public List<string> onkeypCatalogosFacade(string catalogo,string caracteres,Dictionary<string,string> request)
        {
            char[] charsToTrim = { ' ' };
            string result = caracteres.Trim(charsToTrim);
            List<string> coincidencias = new List<string>();
            switch (catalogo)
            {
                case "roles":
                    coincidencias = logicaRol.onkeyupSearch(result);
                    break;
                case "alumnos":
                    coincidencias = studentService.onkeyupSearch(result);
                    break;
                case "grupos":
                    coincidencias = groupService.onkeyupSearch(result);
                    break;
                case "carreras":
                    coincidencias = carrersService.onkeyupSearch(result);
                    break;
                case "cuatrimestres":
                    coincidencias = levelService.onkeyupSearch(result);
                    break;
                case "periodos":
                    coincidencias = periodService.onkeyupSearch(result);
                    break;
                case "materias":
                    coincidencias = SubjectService.onkeyupSearch(result);
                    break;
                case "horas":
                    coincidencias = timesService.onkeyupSearch(result);
                    break;
                case "divisiones":
                    coincidencias = divService.onkeyupSearch(result);
                    break;
                case "edificios":
                    coincidencias = buildingsService.onkeyupSearch(result);
                    break;
                case "studentCandidates":
                    coincidencias = scService.onkeyupSearch(result);
                    break;
                case "typesWorkers":
                    coincidencias = typesWorkers.onkeyupSearch(result);
                    break;
                case "trabajadores":
                    coincidencias = employeService.onkeyupSearch(result, request);
                    break;
                case "tiposDeSalon":
                    coincidencias = typeClassroomService.onkeyupSearch(result);
                    break;
                case "salones":
                    coincidencias = classroomService.onkeyupSearch(result);
                    break;
                case "privilegiosRoles":
                    coincidencias = rolePrivileges.onkeyupSearch(result);
                    break;
            }
            return coincidencias;
        }
    }
}
