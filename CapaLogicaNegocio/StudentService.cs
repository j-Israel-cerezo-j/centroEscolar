using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.Adds;
using Entidades;
using CapaLogicaNegocio.retrieveAtributesValues;
using CapaLogicaNegocio.Lists;
using CapaLogicaNegocio.utils;
using CapaLogicaNegocio.recoverDates;
using CapaLogicaNegocio.deletes;
using CapaLogicaNegocio.updates;
using CapaLogicaNegocio.encryptPassword;
using Newtonsoft.Json;
using CapaLogicaNegocio.validateDuplicateField;
using Validaciones.util;
using CapaLogicaNegocio.Exceptions;
namespace CapaLogicaNegocio
{
    public class StudentService
    {
        private UpdateStudent updateStudents = new UpdateStudent();
        private AddStudent addStudent= new AddStudent();
        private ListarAlumnos listarAlumnos = new ListarAlumnos();
        private DeleteStudent deleteStudent = new DeleteStudent();
        private RecoverDataStudents recoverDatesStudents = new RecoverDataStudents();

        public bool add(Dictionary<string, string> submit) 
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Student student = retriveAttributesSubmit(submit);
                string passConfirm= RetrieveAtributesValues.retrieveAtributesValues(submit, "confirmPassword");                
                validateCampos(student, passConfirm);
                validateDuplicateEmail(student);
                return addStudent.add(student);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }                  
                }
            }            
            return ban;
        }
        private void validateCampos(Student student,string passConfirm)
        {
            if (student.pass!=passConfirm)
            {
                throw new ServiceException("Las contraseñas no coinciden");
            }
            else if (!Validation.LongMin(student.pass,8))
            {
                throw new ServiceException("Longitud de contraseña debe ser minimo a 8 caracteres");
            }else if (!Validation.IsEmail(student.correoP))
            {
                throw new ServiceException("Formato no correcto en correo");
            }           
            else
            {                
                if (!Validation.numericalFormat(student.telefono))
                {
                    throw new ServiceException("Formato no correcto en telefono(solo números)");
                }else if (!Validation.Long(student.telefono, 10, 10))
                {
                    throw new ServiceException("La longitud del telefono tiene que ser no menor a 10 y no mayor a 10");
                }
            }
        }
        private void validateDuplicateEmail(Student student) {

            var existsEmail = DuplicateField.duplicate("correoP", student.correoP, "alumnos");
            if (existsEmail)
            {
                var campos = new Dictionary<string, string>();
                campos.Add("correoP", student.correoP);
                campos.Add("idAlumno", student.idAlumno.ToString());

                var existsEmailAndID = DuplicateField.duplicate(campos, "alumnos");
                if (!existsEmailAndID)
                {
                    throw new ServiceException("Correo ya existente");
                }
            }
        }
        private Student retriveAttributesSubmit(Dictionary<string, string> submit)
        {
            Student student = new Student();
            student.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "nombres");
            student.apellidoP = RetrieveAtributesValues.retrieveAtributesValues(submit, "apellidoP");
            student.apellidoM = RetrieveAtributesValues.retrieveAtributesValues(submit, "apellidoM");
            student.curp = RetrieveAtributesValues.retrieveAtributesValues(submit, "curp");
            student.matricula = UserUtils.GenerateMatricula(student.curp);
            student.pass = RetrieveAtributesValues.retrieveAtributesValues(submit, "password");
            student.correoP = RetrieveAtributesValues.retrieveAtributesValues(submit, "email");
            student.telefono = RetrieveAtributesValues.retrieveAtributesValues(submit, "tel");
            return student;
        }       
        public string jsonStudents()
        {
            List<Student> students = listarAlumnos.listarAlumnos();
            return Converter.ToJson(students);
        }
        public bool deleteStudents(string strIds)
        {
            return deleteStudent.delete(strIds);
        }
        public bool updateStudent(Dictionary<string, string> submit, string strId)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Student student = retriveAttributesSubmit(submit);
                student.idAlumno = Convert.ToInt32(strId);
                string passConfirm = RetrieveAtributesValues.retrieveAtributesValues(submit, "confirmPassword");
                validateCampos(student, passConfirm);
                validateDuplicateEmail(student);
                return updateStudents.update(student);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }       
        public string jsonRecoverData(string strId)
        {
            string jsonRecoerDtes = "";
            if (strId != "")
            {
                var students = new List<Student>();
                students.Add(recoverDatesStudents.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(students);
            }
            return jsonRecoerDtes;
        }
    }
}
