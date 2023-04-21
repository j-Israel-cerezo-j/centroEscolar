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
using CapaLogicaNegocio.MessageErrors;
using System.Data;
using CapaLogicaNegocio.Onkeyups;
using CapaDatos.Exceptions;

namespace CapaLogicaNegocio
{
    public class StudentCandidateService : UserService
    {
        private AddDomicilie addDomicilie = new AddDomicilie();
        private TableCandidates tableCandidates = new TableCandidates();
        private AddStudentCandidate addSCandidate = new AddStudentCandidate();
        private ListStatusCandiadate listStatusCandi = new ListStatusCandiadate();

        public StudentCandidate addCandidateStudentToStudents(Dictionary<string, string> request)
        {
            StudentCandidate studentCandidate = null;
            try
            {
                bool exito = false;
                validateFormantDivisions(request);
                User user = getUserDataFromRequest(request);
                if (user != null)
                {
                    studentCandidate = buildStudentAndAddAddress(user, request);
                    exito = addSCandidate.add(studentCandidate);
                    if (!exito)
                    {
                        rollbackAddress(studentCandidate.fkAddress, 0);
                        throw new ServiceException(MessageError.AnErrorOccurredTryAgainLater);
                    }

                }
            }
            catch (DaoException e)
            {
                rollbackAddress(studentCandidate.fkAddress,0);
                throw new ServiceException(e.getMessage());
            }
            return studentCandidate;
        }
        public string candidateData_EMAILINS_PASSWORD_MATRICULA(StudentCandidate candidate)
        {
            string jsonDatasCandidate = "";
            if (candidate != null)
            {
                jsonDatasCandidate = "" +
                    "{" +
                        "matricula:'"+candidate.matricula+"'," +
                        "correoIns:'"+candidate.correoIns+"'," +
                        "pass:'"+candidate.fechaNac+"'" +
                    "}";
            }
            return jsonDatasCandidate;
        }
        private StudentCandidate buildStudentAndAddAddress(User user, Dictionary<string, string> request)
        {

            StudentCandidate studentCandidate = buildUser(user, new StudentCandidate());
            studentCandidate.fkIdStatus = "NoAprobado";
            studentCandidate.fkIdDivision = Convert.ToInt32(
                                            RetrieveAtributes.values(request, "divisiones"));
            Domicilie domicilie = getDomicilieDataFromRequest(request);
            int idNewAddress = addDomicilie.addAddres(domicilie);
            if (idNewAddress == 0)
            {
                throw new ServiceException(MessageError.AnErrorOccurredTryAgainLater);
            }
            studentCandidate.fkAddress = idNewAddress;
            return studentCandidate;
        }
        public List<string> onkeyupSearch(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            var TableCandidates = tableCandidates.tableCandidatesBymatchingCharacters(caracteres);
            return Converter.ToList(TableCandidates);

        }
        public StringBuilder jsonCandidatesByMatchingCharacters(string characters)
        {
            var TableCandidates = tableCandidates.tableCandidatesBymatchingCharacters(characters);
            return Converter.ToJson(TableCandidates);
        }

        public StringBuilder jsonCandidates()
        {
            var TableCandidates = tableCandidates.tableCandidates();
            return Converter.ToJson(TableCandidates);
        }
        public string jsonStatusCandidate()
        {
            var statusCandidates= listStatusCandi.listarStatusCandidate();
            return Converter.ToJson(statusCandidates);
        }
        public string jsonCandidatesByIDdiv(string strId)
        {
            int id=Convert.ToInt32(strId);
            var students = new DataTable();
            if (id == -2)
            {
                students = tableCandidates.tableCandidates();
            }
            else
            {
                students = tableCandidates.tableCandidatesByIDdivision(id);
            }            
            return Converter.ToJson(students).ToString();
        }
    }
}
