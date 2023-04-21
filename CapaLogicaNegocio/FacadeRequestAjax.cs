using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CapaLogicaNegocio.MessageErrors;
namespace CapaLogicaNegocio
{
    public class FacadeRequestAjax
    {
        private LogicaRol logicaRol = new LogicaRol();
        private StudentService studentService = new StudentService();
        private GroupService groupService = new GroupService(); 
        private CarrersService carrersService = new CarrersService();
        private LevelService levelService = new LevelService();
        private PeriodService periodService = new PeriodService();
        private SubjectService SubjectService = new SubjectService();
        private HoursService timesService=new HoursService();
        private DivisionService divService = new DivisionService();
        private TypeWorkerService typesWorkers = new TypeWorkerService();
        private EmployeService employeService = new EmployeService();
        private BuildingsService buildingsService = new BuildingsService();
        private TypeClassroomService typeClassroomService = new TypeClassroomService();
        private ClassroomService classroomService = new ClassroomService();
        private RolePrivilegesService rolePrivileges = new RolePrivilegesService();
        public bool ajaxRequestCatalogosAdd(string catalogo, Dictionary<string, string> submit, HttpPostedFile file)
        {
            
            bool ban = false;
            switch (catalogo)
            {
                case "roles":
                    ban = logicaRol.add(submit);
                    break;
                case "grupos":
                    ban = groupService.add(submit);
                    break;
                case "carreras":
                    ban = carrersService.add(submit);
                    break;
                case "cuatrimestres":
                    ban = levelService.add(submit);
                    break;
                case "periodos":
                    ban = periodService.add(submit);
                    break;
                case "materias":
                    ban = SubjectService.add(submit);
                    break;
                case "horas":
                    ban = timesService.add(submit);
                    break;
                case "divisiones":
                    ban = divService.add(submit);
                    break;
                case "edificios":
                    ban = buildingsService.add(submit);
                    break;
                case "typesWorkers":
                    ban = typesWorkers.add(submit);
                    break;
                case "trabajadores":
                    ban = employeService.addEmploye(submit, file);
                    break;
                case "tiposDeSalon":
                    ban = typeClassroomService.add(submit);
                    break;
                case "salones":
                    ban = classroomService.add(submit);
                    break;
                case "privilegiosRoles":
                    ban = rolePrivileges.add(submit,true);
                    break;
            }
            return ban;
        }
        public string ajaxRequestCatalogosTable(string catalogue,string typeWorker="")
        {            
            string jsonTable = "";
            switch (catalogue)
            {
                case "roles":
                    jsonTable = logicaRol.jsonRoles();
                    break;
                case "alumnos":
                    jsonTable = studentService.jsonStudents();
                    break;
                case "grupos":
                    jsonTable = groupService.jsonGroups();
                    break;
                case "carreras":
                    jsonTable = carrersService.jsonCarrers();
                    break;
                case "cuatrimestres":
                    jsonTable = levelService.jsonLevels();
                    break;
                case "periodos":
                    jsonTable = periodService.jsonPeriods();
                    break;
                case "materias":
                    jsonTable = SubjectService.jsonSubjects();
                    break;
                case "horas":
                    jsonTable = timesService.jsonHours();
                    break;
                case "divisiones":
                    jsonTable = divService.jsonDivisions();
                    break;
                case "edificios":
                    jsonTable = buildingsService.jsonBuildings();
                    break;
                case "typesWorkers":
                    jsonTable = typesWorkers.jsonTypesWorkers();
                    break;
                case "trabajadores":
                    jsonTable = employeService.buildTableEmployeByTypeWorker(typeWorker);
                    break;
                case "tiposDeSalon":
                    jsonTable = typeClassroomService.jsonTypeClassrooms();
                    break;
                case "salones":
                    jsonTable = classroomService.jsonClasrooms();
                    break;
                case "privilegiosRoles":
                    jsonTable = rolePrivileges.jsonrolesPrivileges();
                    break;
            }
            return jsonTable;
        }
        public bool ajaxRequestDelete(string catalogo,string strIds)
        {            
            bool ban = false;
            switch (catalogo)
            {
                case "roles":
                    ban = logicaRol.deleteRoles(strIds);
                    break;
                case "alumnos":
                    ban = studentService.deleteStudents(strIds);
                    break;
                case "grupos":
                    ban = groupService.deleteG(strIds);
                    break;
                case "carreras":
                    ban = carrersService.deleteCarrers(strIds);
                    break;
                case "cuatrimestres":
                    ban = levelService.deleteLev(strIds);
                    break;
                case "periodos":
                    ban = periodService.deletePeriod(strIds);
                    break;
                case "materias":
                    ban = SubjectService.deleteSubjects(strIds);
                    break;
                case "horas":
                    ban = timesService.deleteHours(strIds);
                    break;
                case "divisiones":
                    ban = divService.deleteDivision(strIds);
                    break;
                case "edificios":
                    ban = buildingsService.deleteBuildings(strIds);
                    break;
                case "typesWorkers":
                    ban = typesWorkers.deleteTypesWorkers(strIds);
                    break;
                case "tiposDeSalon":
                    ban = typeClassroomService.deleteTypeClassroom(strIds);
                    break;
                case "salones":
                    ban = classroomService.deleteClassroom(strIds);
                    break;
                case "privilegiosRoles":
                    ban = rolePrivileges.deletePrivilegesRoles(strIds);
                    break;
            }
            return ban;
        }
        public bool ajaxRequestUpdate(string catalogo, Dictionary<string, string> submit,string strId, HttpPostedFile file)
        {            
            bool ban = false;
            switch (catalogo)
            {
                case "roles":
                    ban = logicaRol.updateRole(submit,strId);
                    break;
                case "alumnos":
                    ban = studentService.updateStudent(submit, strId, file);
                    break ;
                case "grupos":
                    ban = groupService.updateGroup(submit, strId);
                    break;
                case "carreras":
                    ban = carrersService.updateCarrer(submit, strId);
                    break;
                case "cuatrimestres":
                    ban = levelService.updateLevel(submit, strId);
                    break;
                case "periodos":
                    ban = periodService.updatePeriod(submit, strId);
                    break;
                case "materias":
                    ban = SubjectService.updateSubject(submit, strId);
                    break;
                case "horas":
                    ban = timesService.updateHours(submit, strId);
                    break;
                case "divisiones":
                    ban = divService.updateDivision(submit, strId);
                    break;
                case "edificios":
                    ban = buildingsService.updateDivision(submit, strId);
                    break;
                case "typesWorkers":
                    ban = typesWorkers.updateTypesWorkers(submit, strId);
                    break;
                case "trabajadores":
                    ban = employeService.updateEmploye(submit, strId, file);
                    break;
                case "tiposDeSalon":
                    ban = typeClassroomService.updateTypeClassroom(submit, strId);
                    break;
                case "salones":
                    ban = classroomService.updateClassroom(submit, strId);
                    break;
                case "privilegiosRoles":
                    ban = rolePrivileges.update(submit, strId);
                    break;
            }
            return ban;
        }
    }
}
