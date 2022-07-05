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
using System.Data.SqlClient;

namespace CapaLogicaNegocio
{
    public class StudentCandidateService
    {
        private TableCandidates tableCandidates = new TableCandidates();
        private AddDomicilie addDomicilie = new AddDomicilie();
        private AddStudentCandidate addStudentCandidate = new AddStudentCandidate();
        public string add(Dictionary<string, string> submit)
        {
            string jsonStudentCandidate = "";
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {

                validateAttibutres(submit);
                StudentCandidate studentCandidate = retriveAttributesDataPerson(submit);
                var existsEmail = DuplicateField.duplicate("correoP", studentCandidate.correoP, "studentsCantidant");
                if (existsEmail)
                {
                    throw new ServiceException("Correo ya existente");
                }else if (DuplicateField.duplicate("curp", studentCandidate.curp, "studentsCantidant"))
                {
                    throw new ServiceException("Curp ya existente");
                }
                int idStudentCandidateAdd = addStudentCandidate.add(studentCandidate);
                Domicilie domicilie = retriveAttributesDomicilies(submit, idStudentCandidateAdd);
                bool exito= addDomicilie.add(domicilie);
                if (exito)
                {
                    return studentCandidateData(studentCandidate);
                }
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException("El campo " + item.Key + " esta vacío");
                    }
                }
            }
            return jsonStudentCandidate;
        }
        public string studentCandidateData(StudentCandidate studentCandidate)
        {
            var studentCandidates = new Dictionary<string,string>();
            studentCandidates.Add("matricula",studentCandidate.matricula);
            studentCandidates.Add("correoInstitucional", studentCandidate.correoIns);
            studentCandidates.Add("password", studentCandidate.pass);
            return Converter.ToJson(studentCandidates);
        }
        private Domicilie retriveAttributesDomicilies(Dictionary<string, string> submit,int idStudentCandidateAdd)
        {
            Domicilie domicilie = new Domicilie();
            domicilie.calle = RetrieveAtributesValues.retrieveAtributesValues(submit, "nomcalle");
            domicilie.noInterior = RetrieveAtributesValues.retrieveAtributesValues(submit, "noInterior");
            domicilie.noExterior = RetrieveAtributesValues.retrieveAtributesValues(submit, "noExterior");
            domicilie.fkAlumno = idStudentCandidateAdd;
            return domicilie;
        }     
        private void validateAttibutres(Dictionary<string,string> form)
        {
            string strDateOfBirth = RetrieveAtributesValues.retrieveAtributesValues(form, "fechaNac");
            string fkDivision = RetrieveAtributesValues.retrieveAtributesValues(form, "divisiones");
            string strTelefono = RetrieveAtributesValues.retrieveAtributesValues(form, "tel");
            string strEmailPerson = RetrieveAtributesValues.retrieveAtributesValues(form, "email");

            if (!Validation.Select(fkDivision))
            {
                throw new ServiceException("Formato no correcto sobre divisiones");
            }
            else if (!Validation.FormantDate(strDateOfBirth))
            {
                throw new ServiceException("Formato no correcto en fecha de nacimiento");
            }
            else if (!Validation.IsEmail(strEmailPerson))
            {
                throw new ServiceException("Formato no correcto en correo");
            }
            else
            {
                if (!Validation.numericalFormat(strTelefono))
                {
                    throw new ServiceException("Formato no correcto en telefono(solo números)");
                }
                else if (!Validation.Long(strTelefono, 10, 10))
                {
                    throw new ServiceException("La longitud del telefono tiene que ser no menor a 10 y no mayor a 10");
                }
            }
        }
        private StudentCandidate retriveAttributesDataPerson(Dictionary<string, string> submit)
        {
            //fechaNac
            StudentCandidate studentCandidate = new StudentCandidate();
            studentCandidate.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "nombres");
            studentCandidate.apellidoP = RetrieveAtributesValues.retrieveAtributesValues(submit, "apellidoP");
            studentCandidate.apellidoM = RetrieveAtributesValues.retrieveAtributesValues(submit, "apellidoM");
            studentCandidate.curp = RetrieveAtributesValues.retrieveAtributesValues(submit, "curp");
            studentCandidate.matricula = UserUtils.GenerateMatricula(studentCandidate.curp);                        
            studentCandidate.correoIns=UserUtils.GenerateInstitutionalEmail(studentCandidate.matricula);              ;
            studentCandidate.pass = UserUtils.GeneratePasswordUser(studentCandidate.fechaNac);
            studentCandidate.fechaNac = Convert.ToDateTime(
                                        RetrieveAtributesValues.retrieveAtributesValues(submit, "fechaNac"));
            studentCandidate.fkIdDivision = Convert.ToInt32(
                                            RetrieveAtributesValues.retrieveAtributesValues(submit, "divisiones"));
            studentCandidate.telefono = RetrieveAtributesValues.retrieveAtributesValues(submit, "tel");
            studentCandidate.correoP = RetrieveAtributesValues.retrieveAtributesValues(submit, "email");
            return studentCandidate;
        }

        public StringBuilder jsonCandidates()
        {
            var TableCandidates = tableCandidates.tableCandidates();
            return Converter.ToJson(TableCandidates);
        }
        public string jsonCandidatesByIDdiv(string strId)
        {
            int id=Convert.ToInt32(strId);
            var students = tableCandidates.tableCandidatesByIDdivision(id);
            return Converter.ToJson(students).ToString();
        }
    }
}
