using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.Adds;
using Entidades;
using CapaLogicaNegocio.utils;
using CapaLogicaNegocio.recoverDates;
using CapaLogicaNegocio.deletes;
using CapaLogicaNegocio.updates;
using CapaLogicaNegocio.encryptPassword;
using CapaLogicaNegocio.validateDuplicateField;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.tablesInner;
using System.Data;
using CapaLogicaNegocio.MessageErrors;
using System.Web;
using System.Data.SqlClient;
using CapaDatos.Exceptions;

namespace CapaLogicaNegocio
{
    public class StudentService : UserService
    {
        private ApiMexico apiMexico = new ApiMexico();
        private UpdateStudent updateStudents = new UpdateStudent();
        private AddStudent addStudent= new AddStudent();        
        private DeleteStudent deleteStudent = new DeleteStudent();        
        private TableStudents tablesStudent = new TableStudents();
        private RecoverDataStudents recoverDataStudent = new RecoverDataStudents();
        private RecoverDataDomicilie recoverDataAddress = new RecoverDataDomicilie();
        private UpdateStatusCandidate updateStatusCan = new UpdateStatusCandidate();        
        private RecoverDataStudenCandidate recoverDataStudenCandidate = new RecoverDataStudenCandidate();
        private DeleteStudent deleteStuden = new DeleteStudent();
        private UpdateStatusUser updateStatusUser = new UpdateStatusUser();

        public string jsonStudents()
        {
            DataTable table = tablesStudent.tableStudents();
            return Converter.ToJson(table).ToString();
        }
        public bool deleteStudents(string strIds)
        {
            return deleteStudent.delete(strIds);
        }
        public bool updateStudent(Dictionary<string, string> request, string strIdUser, HttpPostedFile file)
        {
            bool exito = false;
            User user = getUserDataFromRequestForUpdate(request, "alumnos", strIdUser);
            try
            {
                if (user != null)
                {
                    Student student = buildUser(user, new Student());
                    student.id = Convert.ToInt32(strIdUser);
                    student.image = defineImagePath(request, file, "students");
                    student.fileName = defineTheSourceOfTheFileName(file, "fileName", "alumnos", "id", student.id.ToString());
                    exito = updateStudents.update(student);

                }
            }
            catch (DaoException e)
            {
                throw new ServiceException(MessageError.errorUpdateUser);
            }
            catch (ServiceException es) {
                throw new ServiceException(es.getMessage());
            }
            return exito;          
        }
        public string jsonRecoverData(string strIdStudent)
        {
            string jsonRecoerDtes = "";
            if (strIdStudent != "")
            {
                var datasStudent = tablesStudent.datasStudent(Convert.ToInt32(strIdStudent));                
                jsonRecoerDtes = Converter.ToJson(datasStudent).ToString();
            }
            return jsonRecoerDtes;
        }
        public string jsonMinicipesByStateStudent(string idAlumno)
        {
            Student student = recoverDataStudent.recoverData(Convert.ToInt32(idAlumno));
            if (student == null)
            {
                throw new ServiceException(MessageError.nonexistentStudent);
            }
            else
            {
                Domicilie domicilie = recoverDataAddress.recoverDataAddress(student.fkAddress);
                if (domicilie == null)
                {
                    throw new ServiceException(MessageError.nonexistentAddress);
                }
                else
                {
                    return apiMexico.recoverDatas("municipios", domicilie.estado);
                }                
            }            
        }
        public List<string> onkeyupSearch(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            var table = tablesStudent.tableStudentBymatchingCharacters(caracteres);
            return Converter.ToList(table);
        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
           var table= tablesStudent.tableStudentBymatchingCharacters(caracteres);
            return Converter.ToJson(table);
        }

        public bool manageStatusCandidate(string strIdStatus, string strIdCandidate)
        {
            bool ban = false;
            int idStudenCandidate = Convert.ToInt32(strIdCandidate);
            StudentCandidate studenCandidate = recoverDataStudenCandidate.recoverDataS(idStudenCandidate);
            studenCandidate.fkIdStatus = strIdStatus;

            if (strIdStatus == "aprobado")
            {
                bool exists = DuplicateField.duplicate("correoIns", studenCandidate.correoIns, "alumnos");
                if (exists)
                {
                    throw new ServiceException(MessageError.alreadyApprovedCandidate);
                }                
                Student student = buildUser(studenCandidate,new Student());
                student.fkIdDivision= studenCandidate.fkIdDivision;
                student.fkStatusUser = "desbloqueado";
                ban = addStudent.add(student);                            
            }
            else if (strIdStatus == "NoAprobado")
            {
                bool exists = DuplicateField.duplicate("matricula", studenCandidate.matricula, "alumnos");
                if (exists)
                {                    
                    ban = deleteStuden.deleteByMatricula(studenCandidate.matricula);
                }               
            }
            if (ban)
            {
                ban=updateStatusCan.update(studenCandidate);
            }
            return ban;
        }
        public bool updateStatus(string fkStatus,string idStudent) 
        {
           return updateStatusUser.updateStatusUsers("alumnos","id", fkStatus,"fkStatusUser", idStudent);
        }
    }
}
