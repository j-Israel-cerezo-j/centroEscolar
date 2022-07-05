using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool ajaxRequestCatalogos(string catalogo, Dictionary<string, string> submit)
        {
            
            bool ban = false;
            switch (catalogo)
            {
                case "roles":
                    ban = logicaRol.add(submit);
                    break;
                case "alumnos":
                    ban = studentService.add(submit);
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
            }
            return ban;
        }
        public string ajaxRequestCatalogosTable(string add)
        {            
            string jsonTable = "";
            switch (add)
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
            }
            return ban;
        }
        public bool ajaxRequestUpdate(string catalogo, Dictionary<string, string> submit,string strId)
        {            
            bool ban = false;
            switch (catalogo)
            {
                case "roles":
                    ban = logicaRol.updateRole(submit,strId);
                    break;
                case "alumnos":
                    ban = studentService.updateStudent(submit, strId);
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
            }
            return ban;
        }
    }
}
