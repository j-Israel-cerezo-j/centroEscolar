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
    public class StudentCandidateService
    {
        private AddDomicilie addDomicilie = new AddDomicilie();
        private AddStudentCandidate addStudentCandidate = new AddStudentCandidate();
        public string add(Dictionary<string, string> submit)
        {
            string jsonStudentCandidate = "";
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                string dateNac = RetrieveAtributesValues.retrieveAtributesValues(submit, "fechaNac");
                string fkDivision = RetrieveAtributesValues.retrieveAtributesValues(submit, "divisiones");
                validateFormantDate(dateNac);
                validateFormantDivision(fkDivision);
                StudentCandidate studentCandidate = retriveAttributesDataPerson(submit);
                validateAttibutres(studentCandidate);
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
        private void validateFormantDivision(string select)
        {
            if (!Validation.Select(select))
            {
                throw new ServiceException("Formato no correcto sobre divisiones");
            }
        }
        private void validateAttibutres(StudentCandidate studentCandidate)
        {
            if (!Validation.IsEmail(studentCandidate.correoP))
            {
                throw new ServiceException("Formato no correcto en correo");
            }
            else
            {
                if (!Validation.numericalFormat(studentCandidate.telefono))
                {
                    throw new ServiceException("Formato no correcto en telefono(solo números)");
                }
                else if (!Validation.Long(studentCandidate.telefono, 10, 10))
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
            studentCandidate.correoP = RetrieveAtributesValues.retrieveAtributesValues(submit, "email");
            studentCandidate.correoIns=UserUtils.GenerateInstitutionalEmail(studentCandidate.matricula);  
            studentCandidate.telefono = RetrieveAtributesValues.retrieveAtributesValues(submit, "tel");
            studentCandidate.fechaNac = 
                                    Convert.ToDateTime( RetrieveAtributesValues.retrieveAtributesValues(submit, "fechaNac"));
            studentCandidate.fkIdDivision = Convert.ToInt32(
                                            RetrieveAtributesValues.retrieveAtributesValues(submit, "divisiones")
                                            );
            studentCandidate.pass = UserUtils.GeneratePasswordUser(studentCandidate.fechaNac);
            return studentCandidate;
        }  
        private void validateFormantDate(string date)
        {            
            if (!Validation.FormantDate(date))
            {
                throw new ServiceException("Formato no correcto en fecha de nacimiento");
            }
        }
    }
}
