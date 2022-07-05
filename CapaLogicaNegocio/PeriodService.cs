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
    public class PeriodService
    {
        private addPeriod addP = new addPeriod();
        private ListPeriod listP = new ListPeriod();
        private RecoverDataPeriod recoverDatesP = new RecoverDataPeriod();
        private UpdatePeriod updateP = new UpdatePeriod();
        private DeletePeriod deleteP = new DeletePeriod();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Period period = new Period();
                period.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "periodo");
                string strStartDate = RetrieveAtributesValues.retrieveAtributesValues(submit, "fechaInicio");
                string strEndDate = RetrieveAtributesValues.retrieveAtributesValues(submit, "fechaFinal");
                vaalidedFormantDates(strStartDate, strEndDate);
                period.fechaInicio =Convert.ToDateTime(strStartDate);
                period.fechaTermino =Convert.ToDateTime(strEndDate);
                return addP.add(period);
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
                var periods = new List<Period>();
                periods.Add(recoverDatesP.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(periods);
            }
            return jsonRecoerDtes;
        }
        public string jsonPeriods()
        {
            List<Period> periods = listP.listar();
            return Converter.ToJson(periods);
        }
        public bool updatePeriod(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Period period = new Period();
                period.idPeriodo = Convert.ToInt32(strId);
                period.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "periodo");
                string strStartDate = RetrieveAtributesValues.retrieveAtributesValues(submit, "fechaInicio");
                string strEndDate = RetrieveAtributesValues.retrieveAtributesValues(submit, "fechaFinal");
                vaalidedFormantDates(strStartDate, strEndDate);
                period.fechaInicio = Convert.ToDateTime(strStartDate);
                period.fechaTermino = Convert.ToDateTime(strEndDate);
                return updateP.update(period);
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
        public bool deletePeriod(string strIds)
        {
            return deleteP.delete(strIds);
        }
        private void vaalidedFormantDates(string strStartDate, string strEndDate)
        {
            if (!Validation.FormantDate(strStartDate))
            {
                throw new ServiceException("Formato no correcto sobre fecha de inicio");
            }
            else if (!Validation.FormantDate(strEndDate))
            {
                throw new ServiceException("Formato no correcto sobre fecha de término");
            }
        }
    }
}
