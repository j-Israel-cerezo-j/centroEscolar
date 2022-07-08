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

namespace CapaLogicaNegocio
{
    public class UserService
    {        
        private TableCandidates tableCandidates = new TableCandidates();
        private UpdateStatusCandidate updateStatusCan=new UpdateStatusCandidate();
        private AddStudent addStudent = new AddStudent();
        private ListStatusCandiadate listStatusCandi = new ListStatusCandiadate();
        private DeleteStudent deleteStuden = new DeleteStudent();
        private RecoverDataStudenCandidate recoverDataStudenCandidate = new RecoverDataStudenCandidate();
        private RecoverDataDomicilie recoverDataDomicilie = new RecoverDataDomicilie();
        private AddDomicilie addDomicilie = new AddDomicilie();
        private DeleteDomicilie deleteDomicilies = new DeleteDomicilie();
        private RecoverDataStudents recoverDataStudent = new RecoverDataStudents();
        public bool manageStatusCandidate(string strIdStatus,string strIdCandidate)
        {            
            bool ban=false;
            int idStudenCandidate = Convert.ToInt32(strIdCandidate);
            StudentCandidate studenCandidate = recoverDataStudenCandidate.recoverDataS(idStudenCandidate);
            studenCandidate.fkIdStatus = strIdStatus;

            if (strIdStatus== "aprobado")
            {
                bool exists = DuplicateField.duplicate("correoIns", studenCandidate.correoIns, "alumnos");
                if (exists)
                {
                    throw new ServiceException("Candidato ya aprobado");
                }
                studenCandidate= updateStatusCan.update(studenCandidate);
                Domicilie domicilie = retriveAddresByCandidate(studenCandidate.idCandidato);
                int idNewAddress=addDomicilie.addAddres(domicilie);              
                Student student= retriveDataStudentByCandidate(studenCandidate, idNewAddress);
                return addStudent.add(student);
            }else if(strIdStatus== "NoAprobado")
            {                
                bool exists= DuplicateField.duplicate("matricula", studenCandidate.matricula, "alumnos");
                if (exists)
                {
                    Student student = recoverDataStudent.recoverDataByMatricula(studenCandidate.matricula);
                    bool existsDeleteDomicilie = deleteDomicilies.delete(student.fkDomicilio);
                    if (existsDeleteDomicilie)
                    {
                        ban = deleteStuden.deleteByMatricula(studenCandidate.matricula);
                        studenCandidate = updateStatusCan.update(studenCandidate);
                    }                    
                }
                else
                {
                    ban = true;
                }
            }
            return ban;
        }
        private Student retriveDataStudentByCandidate(StudentCandidate studenCandidate, int idNewAddress)
        {
            Student student = new Student();
            student.matricula = studenCandidate.matricula;
            student.nombres = studenCandidate.nombres;
            student.apellidoP = studenCandidate.apellidoP;
            student.apellidoM = studenCandidate.apellidoM;
            student.curp = studenCandidate.curp;
            student.pass = EncryptPassword.GetMD5(studenCandidate.pass);
            student.correoP = studenCandidate.correoP;
            student.telefono = studenCandidate.telefono;
            student.fkIdDivision = studenCandidate.fkIdDivision;
            student.correoIns = studenCandidate.correoIns;
            student.fechaNac = studenCandidate.fechaNac;
            student.fkDomicilio = idNewAddress;
            return student;
        }
        private Domicilie retriveAddresByCandidate(int idCandidate)
        {
            return recoverDataDomicilie.recoverData(idCandidate);
        }
        public string jsonCandidates()
        {
            var TableCandidates = tableCandidates.tableCandidates();
            return Converter.ToJson(TableCandidates).ToString();
        }
        public string jsonStatusCandidate()
        {
            var statusCandidates = listStatusCandi.listarStatusCandidate();
            return Converter.ToJson(statusCandidates);
        }
    }
}
