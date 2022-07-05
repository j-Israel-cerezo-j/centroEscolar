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
using Validaciones.util;
using CapaLogicaNegocio.Exceptions;
namespace CapaLogicaNegocio
{
    public class SubjectService
    {
        private AddSubject addSub = new AddSubject();
        private ListSubject listSub = new ListSubject();
        private RecoverDataSubject recoverDatesSub = new RecoverDataSubject();
        private UpdateSubject updateSub = new UpdateSubject();
        private DeleteSubject deleteSub = new DeleteSubject();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Subject subject = new Subject();
                subject.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "materia"); ;
                return addSub.add(subject);
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
                var subject = new List<Subject>();
                subject.Add(recoverDatesSub.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(subject);
            }
            return jsonRecoerDtes;
        }
        public string jsonSubjects()
        {
            List<Subject> subjects = listSub.listar();
            return Converter.ToJson(subjects);
        }
        public bool updateSubject(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Subject subject = new Subject();
                subject.idMateria = Convert.ToInt32(strId);
                subject.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "materia");
                return updateSub.update(subject);
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
        public bool deleteSubjects(string strIds)
        {
            return deleteSub.delete(strIds);
        }
    }
}
