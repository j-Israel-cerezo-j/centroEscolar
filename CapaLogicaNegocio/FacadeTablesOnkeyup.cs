using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class FacadeTablesOnkeyup
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
        public string onkeypCatalogosFacadeTables(string catalogo, string caracteres,Dictionary<string,string> request)
        {
            char[] charsToTrim = { ' ' };
            string result = caracteres.Trim(charsToTrim);
            result = "%"+result+"%";
            string jsonTable = "";
            switch (catalogo)
            {
                case "roles":
                    jsonTable = logicaRol.onkeyupSearchTable(result).ToString();
                    break;
                case "alumnos":
                    jsonTable = studentService.onkeyupSearchTable(result).ToString();
                    break;
                case "grupos":
                    jsonTable = groupService.onkeyupSearchTable(result).ToString();
                    break;
                case "carreras":
                    jsonTable = carrersService.onkeyupSearchTable(result).ToString();
                    break;
                case "cuatrimestres":
                    jsonTable = levelService.onkeyupSearchTable(result).ToString();
                    break;
                case "periodos":
                    jsonTable = periodService.onkeyupSearchTable(result).ToString();
                    break;
                case "materias":
                    jsonTable = SubjectService.onkeyupSearchTable(result).ToString();
                    break;
                case "horas":
                    jsonTable = timesService.onkeyupSearchTable(result).ToString();
                    break;
                case "divisiones":
                    jsonTable = divService.onkeyupSearchTable(result).ToString();
                    break;
                case "edificios":
                    jsonTable = buildingsService.onkeyupSearchTable(result).ToString();
                    break;
                case "studentCandidates":
                    jsonTable = scService.jsonCandidatesByMatchingCharacters(result).ToString();
                    break;
                case "typesWorkers":
                    jsonTable = typesWorkers.onkeyupSearchTable(result).ToString();
                    break;
                case "trabajadores":
                    jsonTable = employeService.onkeyupSearchTable(result, request).ToString();
                    break;
                case "tiposDeSalon":
                    jsonTable = typeClassroomService.onkeyupSearchTable(result).ToString();
                    break;
                case "salones":
                    jsonTable = classroomService.onkeyupSearchTable(result).ToString();
                    break;
                case "privilegiosRoles":
                    jsonTable = rolePrivileges.onkeyupSearchTable(result).ToString();
                    break;
            }
            return jsonTable;
        }
    }
}
