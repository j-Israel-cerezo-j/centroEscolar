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
using CapaLogicaNegocio.tablesInner;
using System.Data;

namespace CapaLogicaNegocio
{
    public class StudentService
    {
        private UpdateStudent updateStudents = new UpdateStudent();
        private AddStudent addStudent= new AddStudent();        
        private DeleteStudent deleteStudent = new DeleteStudent();        
        private TableStudents tablesStudent = new TableStudents();
        private UpdateAddress updateAdddress = new UpdateAddress();
        public bool add(Dictionary<string, string> submit) 
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Student student = retriveAttributesSubmit(submit);
                validateCampos(student);
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
        private void validateCampos(Student student)
        {
            if (!Validation.IsEmail(student.correoP))
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
        private Domicilie retriveAttributesSubmitDomicilie(Dictionary<string, string> submit)
        {
            Domicilie domicilie = new Domicilie();
            domicilie.calle = RetrieveAtributesValues.retrieveAtributesValues(submit, "nomcalle");
            domicilie.noExterior = RetrieveAtributesValues.retrieveAtributesValues(submit, "noInterior");
            domicilie.noInterior = RetrieveAtributesValues.retrieveAtributesValues(submit, "noExterior");

            domicilie.estado = RetrieveAtributesValues.retrieveAtributesValues(submit, "state");
            domicilie.municipio = RetrieveAtributesValues.retrieveAtributesValues(submit, "municipio");
            domicilie.cp = RetrieveAtributesValues.retrieveAtributesValues(submit, "cp");
            domicilie.colonia = RetrieveAtributesValues.retrieveAtributesValues(submit, "colonia");


            domicilie.idDomicilio =Convert.ToInt32(
                                                    RetrieveAtributesValues.retrieveAtributesValues(submit, "idDomicilie"));
            return domicilie;
        }

        private Student retriveAttributesSubmit(Dictionary<string, string> submit)
        {
            Student student = new Student();
            student.nombres = RetrieveAtributesValues.retrieveAtributesValues(submit, "nombres");
            student.apellidoP = RetrieveAtributesValues.retrieveAtributesValues(submit, "apellidoP");
            student.apellidoM = RetrieveAtributesValues.retrieveAtributesValues(submit, "apellidoM");
            student.correoP = RetrieveAtributesValues.retrieveAtributesValues(submit, "email");
            student.telefono = RetrieveAtributesValues.retrieveAtributesValues(submit, "tel");
            return student;
        }       
        public string jsonStudents()
        {
            DataTable table = tablesStudent.tableStudents();
            return Converter.ToJson(table).ToString();
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
                validateCamposDomicilie(submit);
                Student student = retriveAttributesSubmit(submit);
                student.idAlumno = Convert.ToInt32(strId);
                Domicilie domicilie = retriveAttributesSubmitDomicilie(submit);
                validateCampos(student);
                validateDuplicateEmail(student);
                bool updateExists = updateAdddress.update(domicilie);
                if (updateExists)
                {
                    return updateStudents.update(student);
                }                
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
        private void validateCamposDomicilie(Dictionary<string,string> form)
        {
            string strEstado = RetrieveAtributesValues.retrieveAtributesValues(form, "state");
            string strMunicipio = RetrieveAtributesValues.retrieveAtributesValues(form, "municipio");
            string strCP = RetrieveAtributesValues.retrieveAtributesValues(form, "cp");
            string strColonia = RetrieveAtributesValues.retrieveAtributesValues(form, "colonia");

            if (!Validation.Select(strEstado))
            {
                throw new ServiceException("Formato no correcto en el estado");
            }
            else if (!Validation.Select(strMunicipio))
            {
                throw new ServiceException("Formato no correcto sobre municipio");
            }
            else if (!Validation.Select(strCP))
            {
                throw new ServiceException("Formato no correcto sobre CP");
            }
            else if (!Validation.Select(strColonia))
            {
                throw new ServiceException("Formato no correcto sobre la colonia");
            }
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
    }
}
